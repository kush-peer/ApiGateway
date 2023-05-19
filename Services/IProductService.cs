using ApiGateway.Models;

namespace ApiGateway.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>?> GetProducts();
    }
}
