using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDTO> GetAsync(int id);
    }

    public class ProductQueryService: IProductQueryService
    {
        private readonly ApplicationDbContext _context;
        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<DataCollection<ProductDTO>> GetAllAsync(int page, int take, IEnumerable<int> products =null)
        {
            var collection = await _context.Products
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderByDescending(x => x.ProductId)
                .GetPagedAsync(page, take);
            return collection.MapTo<DataCollection<ProductDTO>>();
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            return (await _context.Products.SingleAsync(x => x.ProductId == id)).MapTo<ProductDTO>();
        }
    }
}
