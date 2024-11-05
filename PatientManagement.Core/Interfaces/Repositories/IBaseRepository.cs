using ErrorOr;
using PatientManagement.Core.Entities;

namespace PatientManagement.Core.Interfaces.Repositories
{
    /// <summary>
    /// Generic repository interface defining common operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this repository works with.</typeparam>
    /// <summary>
    /// Generic repository interface with ErrorOr return types.
    /// </summary>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        Task<ErrorOr<IReadOnlyList<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        Task<ErrorOr<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        Task<ErrorOr<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        Task<ErrorOr<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        Task<ErrorOr<Deleted>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets entities with pagination.
        /// </summary>
        Task<ErrorOr<(IReadOnlyList<TEntity> Items, int TotalCount)>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default);
    }
}
