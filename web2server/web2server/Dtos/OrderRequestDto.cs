namespace web2server.Dtos
{
    public class OrderRequestDto
    {
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public long ArticleId { get; set; }
    }
}
