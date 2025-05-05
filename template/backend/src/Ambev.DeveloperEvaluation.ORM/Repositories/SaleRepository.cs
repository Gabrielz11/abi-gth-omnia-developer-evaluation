using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }
        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await _context.Sales.FindAsync(new object[] { id }, cancellationToken);
            if (sale is null)
                return false;
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Select all the sale from the database
        /// </summary>
        /// <param name="skip">The number of items to skip for pagination</param>
        /// <param name="take">The number of items to retrieve for pagination</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sales, or null if none are found.</returns>
        public async Task<List<Sale>?> GetAllAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Update a sale by their unique identifier
        /// </summary>
        /// <param name="sale">The sale find</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was update, false if not found</returns>
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            var objectSale = await _context.Sales.FindAsync(new object[] { sale.Id }, cancellationToken);
            if (objectSale is null)
                throw new KeyNotFoundException($"Sale with ID {sale.Id} not found.");

            _context.Entry(objectSale).CurrentValues.SetValues(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return objectSale;
        }
    }
}
