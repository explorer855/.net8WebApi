using Domain.Entities;

namespace Infrastructure.Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product?> GetProductById(Guid productId);
        Task<Product?> UpdateProduct(Guid productId, Product product);
        Task<bool> DeleteProduct(Guid productId);
    }
}
