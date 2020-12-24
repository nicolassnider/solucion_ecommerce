using Catalog.Domain;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalog.Service.EventHandlers;
using Moq;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using System.Threading;
using System.Collections.Generic;
using static Catalog.Common.Enums;
using System;
using System.Linq;

namespace Catalog.Tests
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>()
                    .Object;
            }
        }
        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextIntMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });
            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand {
                Items = new List<ProductInStockUpdateItem>() { 
                    new ProductInStockUpdateItem
                    {
                        ProductId=productId,
                        Stock = 1,
                        Action = ProducInStockAction.Substract
                    }
                }            
            }, new CancellationToken()).Wait(); 
        }
        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasntStock()
        {
            var context = ApplicationDbContextIntMemory.Get();

            var productInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 2
            });
            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            try
            {
                handler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId=productId,
                        Stock = 123456789,
                        Action = ProducInStockAction.Substract
                    }
                }
                }, new CancellationToken()).Wait();
            }
            catch (Exception ae)
            {

                var exception = ae.GetBaseException();

                if (exception is ProductInStockUpdateStockCommandException)
                {
                    throw new ProductInStockUpdateStockCommandException(exception?.InnerException?.Message);
                }
            }

            
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextIntMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });
            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId=productId,
                        Stock = 2,
                        Action = ProducInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;
            Assert.AreEqual(stockInDb, 3);
        }
        [TestMethod]
        public void TryToAddStockWhenProductDoesntExists()
        {
            var context = ApplicationDbContextIntMemory.Get();

           var productId = 4;

            //no se agrega el producto
            //context.Stocks.Add(new ProductInStock
            //{
            //    ProductInStockId = productInStockId,
            //    ProductId = productId,
            //    Stock = 1
            //});
            //context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId=productId,
                        Stock = 2,
                        Action = ProducInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;
            Assert.AreEqual(stockInDb, 2);
        }
    }
}
