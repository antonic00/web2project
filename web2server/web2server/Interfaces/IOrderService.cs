using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IOrderService
    {
        List<OrderResponseDto> GetAllOrders();
        OrderResponseDto GetOrderById(long id);
        OrderResponseDto CreateOrder(OrderRequestDto requestDto, long userId);
        void CancelOrder(long id, long userId);
    }
}
