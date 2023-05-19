using ApiGateway.Models;

namespace ApiGateway.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<ProductOrder>?> GetOrders();
    }
}
