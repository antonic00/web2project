using AutoMapper;
using EntityFramework.Exceptions.Common;
using web2server.Dtos;
using web2server.Enums;
using web2server.Exceptions;
using web2server.Infrastructure;
using web2server.Interfaces;
using web2server.Models;

namespace web2server.Services
{
    public class OrderService : IOrderService
    {
        private readonly WebshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(WebshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<OrderDto> GetAllOrders()
        {
            return _mapper.Map<List<OrderDto>>(_dbContext.Orders.ToList());
        }

        public OrderDto GetOrderById(long id)
        {
            OrderDto order = _mapper.Map<OrderDto>(_dbContext.Orders.Find(id));

            if (order == null)
            {
                throw new ResourceNotFoundException("Order with specified id doesn't exist!");
            }

            return order;
        }

        public OrderDto CreateOrder(OrderDto orderDto, long userId)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order.BuyerId = userId;

            Article article = _dbContext.Articles.Find(order.ArticleId);

            if (article == null)
            {
                throw new ResourceNotFoundException("Article with specified id doesn't exist!");
            }

            if (article.Quantity < order.Quantity)
            {
                throw new InvalidFieldsException("There are not enough articles in stock!");
            }

            article.Quantity -= order.Quantity;
            order.OrderStatus = OrderStatus.Pending;
            order.Price = article.Price * order.Quantity;
            order.CreatedAt = DateTime.UtcNow;
            order.DeliveryTime = new Random().Next(1, 25);

            _dbContext.Orders.Add(order);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (CannotInsertNullException)
            {
                throw new InvalidFieldsException("One of more fields are missing!");
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<OrderDto>(order);
        }

        public void CancelOrder(long id, long userId)
        {
            Order order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                throw new ResourceNotFoundException("Order with specified id doesn't exist!");
            }

            if (order.BuyerId != userId)
            {
                throw new ForbiddenActionException("Buyers can only cancel their own orders!");
            }

            Article article = _dbContext.Articles.Find(order.ArticleId);

            if (article == null)
            {
                throw new ResourceNotFoundException("Article with specified id doesn't exist!");
            }

            article.Quantity += order.Quantity;

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
