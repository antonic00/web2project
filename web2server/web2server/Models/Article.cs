namespace web2server.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public long SellerId { get; set; }
        public User Seller { get; set; }
    }
}
