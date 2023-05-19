using System.Net;
using ApiGateway.Models;
using ApiGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{productId}", Name = "GetOrderByProductId")]
        [ProducesResponseType(typeof(ProductOrder), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductOrder>> GetProducts(int productId)
        {
            var products = await _productService.GetProducts();

            // do mapping of DTOs if any. 
            var prodId = products?.Where(x => x.Id == productId).FirstOrDefault()?.Id;

            // call order service 
            var productOrders = await _orderService.GetOrders();

           // do any orchestration/ request aggregation - target n number of internal micro-services here 
            // collect data, perform transformation 

            // do mapping of DTOs is any 

            // call shipOrder Service 

            return Ok(productOrders);

            // Cross Cutting common features 
            //    Authentication and authorization
            //    Service discovery integration
            //    Response caching
            //    Retry policies, circuit breaker, and QoS
            //    Rate limiting and throttling
            //    Load balancing
            //    Logging, tracing, correlation
            //    Headers, query strings, and claims transformation
            //    IP allowlisting
        }
    }
}
