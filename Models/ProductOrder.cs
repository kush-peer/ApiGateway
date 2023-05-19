namespace ApiGateway.Models
{
    public class ProductOrder
    {
        public class Detail
        {
            public int ProductID { get; set; }
            public string Product { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
        public List<Detail> Details { get; set; }
    }
}
