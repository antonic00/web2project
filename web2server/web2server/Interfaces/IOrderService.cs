using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderById(long id);
        OrderDto CreateOrder(OrderDto orderDto, long userId);
        void CancelOrder(long id, long userId);
    }
}
