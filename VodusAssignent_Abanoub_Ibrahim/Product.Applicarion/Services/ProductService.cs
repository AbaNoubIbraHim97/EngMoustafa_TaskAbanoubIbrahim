using Product.Domain.Dtos;
using Product.Domain.Interfaces;
using Product.Infrastrucre.Services;

namespace Product.Applicarion.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {

            return await _productRepository.GetAllProducts();

        }

        public void AddProduct(AddProductDto productDto)
        {

            var product = new Product.Domain.Models.Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Email= productDto.Email,
                PhoneNumber= productDto.PhoneNumber,
            };
            _productRepository.AddProduct(product);
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Email = product.Email,
                PhoneNumber = product.PhoneNumber,
            };
        }
        public async Task<bool> UpdateProductAsync(int id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
              return false;
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Email = productDto.Email;
            existingProduct.PhoneNumber = productDto.PhoneNumber;
            await _productRepository.UpdateProductAsync(existingProduct);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            await _productRepository.DeleteProductAsync(id);
            return true;
        }

       
    }
}
