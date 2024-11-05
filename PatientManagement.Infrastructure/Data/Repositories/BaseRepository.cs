using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Common.Errors;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Interfaces.Repositories;

namespace PatientManagement.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Base repository implementation with ErrorOr pattern.
    /// </summary>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly PatientManagementDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(PatientManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<ErrorOr<IReadOnlyList<TEntity>>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entities = await _dbSet.ToListAsync(cancellationToken);
                return entities;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public virtual async Task<ErrorOr<TEntity>> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
                if (entity is null)
                {
                    return Error.NotFound(description: $"Entity with Id {id} not found");
                }

                return entity;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public virtual async Task<ErrorOr<TEntity>> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.General.ConcurrencyConflict;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public virtual async Task<ErrorOr<TEntity>> UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.General.ConcurrencyConflict;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public virtual async Task<ErrorOr<Deleted>> DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
                if (entity is null)
                {
                    return Error.NotFound(description: $"Entity with Id {id} not found");
                }

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Deleted;
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.General.ConcurrencyConflict;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public virtual async Task<ErrorOr<(IReadOnlyList<TEntity> Items, int TotalCount)>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var totalCount = await _dbSet.CountAsync(cancellationToken);
                var items = await _dbSet
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                return (items, totalCount);
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        protected virtual IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query)
        {
            return query;
        }
    }
}
