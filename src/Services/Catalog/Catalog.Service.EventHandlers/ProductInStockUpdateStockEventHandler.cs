using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Persistence.Database;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Catalog.Common.Enums;
using Microsoft.Extensions.Logging;

namespace Catalog.Service.EventHandlers
    
{
    class ProductInStockUpdateStockEventHandler
        : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(
            ApplicationDbContext context,
            ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");
            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrieve products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProducInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product {entry.ProductId} - doesn´t have enough stock");
                        throw new Exception($"Product {entry.ProductId} - doesn´t have enough stock");
                    }
                    _logger.LogInformation($"Product {entry.ProductId} - stock substracted");
                    entry.Stock -= item.Stock;

                }
                else
                {
                    if (entry==null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };
                        await _context.AddAsync(entry);
                        _logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists before");

                    }
                    _logger.LogInformation($"--- Add stock to product {entry.ProductId}");
                    entry.Stock += item.Stock;
                }
            }
            await _context.SaveChangesAsync();
            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");

        }
    }

    
}
