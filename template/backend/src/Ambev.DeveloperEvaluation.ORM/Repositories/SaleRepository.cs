using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            
            if (sale is null)
                return false;

            _context.SaleItems.RemoveRange(sale.Items);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (sale is null)
                return false;

            sale.IsCancelled = true;
            
            foreach (var item in sale.Items)
            {
                item.IsCancelled = true;
            }

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CancelItemAsync(Guid saleId,Guid itemId, CancellationToken cancellationToken = default)
        {
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == saleId, cancellationToken);

            if (sale is null)
                return false;

            var item = sale.Items.FirstOrDefault(key => key.Id == itemId);

            if (item is null)
                return false;

            item.IsCancelled = true;

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Sale>?> GetAllAsync(int? skip, int? take, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                 .OrderBy(key => key.Customer)
                 .Skip(skip ?? 0)
                 .Take(take ?? 10)
                 .ToListAsync(cancellationToken);
        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        //updateAsync
        public async Task<Sale> UpdateAsync(Sale saleRequest, CancellationToken cancellationToken = default)
        {
            var existingSale = await _context.Sales
             .Include(s => s.Items)
             .FirstOrDefaultAsync(s => s.Id == saleRequest.Id, cancellationToken);

            if (existingSale == null)
                throw new KeyNotFoundException($"Sale with ID {saleRequest.Id} not found.");

            existingSale.Customer = saleRequest.Customer;
            existingSale.Branch = saleRequest.Branch;
            existingSale.Date = saleRequest.Date;
            for (int i = 0; i < saleRequest.Items.Count; i++)
            {
                existingSale.Items[i].Product = saleRequest.Items[i].Product;
                existingSale.Items[i].Quantity = saleRequest.Items[i].Quantity;
                existingSale.Items[i].UnitPrice = saleRequest.Items[i].UnitPrice;
                existingSale.Items[i].Discount = saleRequest.Items[i].Discount;
                existingSale.Items[i].IsCancelled = saleRequest.Items[i].IsCancelled;
            }
            existingSale.TotalAmount = saleRequest.TotalAmount;
            existingSale.IsCancelled = saleRequest.IsCancelled;

            _context.Sales.Update(existingSale);
            await _context.SaveChangesAsync(cancellationToken);
            return existingSale;
        }

    }
}
