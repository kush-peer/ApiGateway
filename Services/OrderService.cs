using ApiGateway.Extensions;
using ApiGateway.Models;

namespace ApiGateway.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<ProductOrder>?> GetOrders()
        {
            var response = await _client.GetAsync($"/api/Orders/GetOrders");
            return await response.ReadContentAs<List<ProductOrder>>();
        }
    }
}
