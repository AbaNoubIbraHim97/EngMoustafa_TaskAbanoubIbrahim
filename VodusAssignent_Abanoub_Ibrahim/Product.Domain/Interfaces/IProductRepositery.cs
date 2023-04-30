
using Product.Domain.Dtos;
namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        void AddProduct(Product.Domain.Models.Product product);
        Task<Product.Domain.Models.Product> GetProductByIdAsync(int id);
        Task<Product.Domain.Models.Product> UpdateProductAsync(Models.Product product);
        Task DeleteProductAsync(int id);
  
    }
}
