namespace DevApplication1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set; } = default!;
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = default!;
    }
}
