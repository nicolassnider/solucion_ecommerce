using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Persistence.Database;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;

namespace Catalog.Service.EventHandlers
{
    
    class ProductCreateEventHandler
        : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            }
                );

            await _context.SaveChangesAsync();

        }

        


        //TODO: ProductUpdate command
        //TODO: ProductDelete command
    }
}
