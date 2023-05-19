using ApiGateway.Extensions;
using ApiGateway.Models;

namespace ApiGateway.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<Product>?> GetProducts()
        {
            var response = await _client.GetAsync($"/api/products/GetProducts");
            return await response.ReadContentAs<List<Product>>();
        }
    }
}
