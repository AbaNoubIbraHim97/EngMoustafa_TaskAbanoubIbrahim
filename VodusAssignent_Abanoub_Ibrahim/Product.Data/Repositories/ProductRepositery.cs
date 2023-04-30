using Microsoft.EntityFrameworkCore;
using Product.Domain.Dtos;
using Product.Domain.Interfaces;
using Product.Infrastrucre.Context;

namespace VodusAssignent_Abanoub_Ibrahim.Repositery
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products =await _dbContext.Product.Select( p=> new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Email= p.Email,
                PhoneNumber= p.PhoneNumber,
            }).ToListAsync();
            return products;

        }
        public void AddProduct(Product.Domain.Models.Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
        }

        public async Task<Product.Domain.Models.Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Product.FindAsync(id);
        }
        public async Task<Product.Domain.Models.Product> UpdateProductAsync(Product.Domain.Models.Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        
      
    }
}
