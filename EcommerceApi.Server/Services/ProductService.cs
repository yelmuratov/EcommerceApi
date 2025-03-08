using EcommerceApi.Server.DTOs.ProductDTOs;
using EcommerceApi.Server.Models;
using EcommerceApi.Server.ProductInterfaces;

namespace EcommerceApi.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImagePath,
            }).ToList();
        }

        public async Task<ProductDTO?> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImagePath,
            };
        }

        public async Task<ProductDTO> CreateProduct(ProductCreateDTO productDto)
        {
            var newProduct = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
            };

            var createdProduct = await _productRepository.AddAsync(newProduct);

            return new ProductDTO
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                ImageUrl = createdProduct.ImagePath,
            };
        }

        public async Task<ProductDTO?> UpdateProduct(int id, ProductCreateDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;

            await _productRepository.UpdateAsync(product);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImagePath,
            };
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
