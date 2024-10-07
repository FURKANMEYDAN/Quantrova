using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Persistence.Context;


namespace Shop.WebApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductListWithProductImagesAsync()
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Include(p => p.CategoryDetail)
                .ToListAsync();                

        }

        
    }
}
