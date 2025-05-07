using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<List<Sale>?> GetAllAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> CancelItemAsync(Guid saleId,Guid itemId, CancellationToken cancellationToken = default);
    }
}
