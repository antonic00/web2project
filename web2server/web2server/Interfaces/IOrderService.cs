using web2server.Dtos;
using web2server.QueryParametars;

namespace web2server.Interfaces
{
    public interface IOrderService
    {
        List<OrderResponseDto> GetAllOrders(OrderQueryParameters queryParameters);
        OrderResponseDto GetOrderById(long id);
        OrderResponseDto CreateOrder(OrderRequestDto requestDto, long userId);
        DeleteResponseDto CancelOrder(long id, long userId);
    }
}
