

using Product.Domain.Dtos;

namespace Product.Infrastrucre.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        void AddProduct(AddProductDto product);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(int id, ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);

    }
}
