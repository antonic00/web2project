using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web2server.Dtos;
using web2server.Exceptions;
using web2server.Interfaces;

namespace web2server.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(long id)
        {
            OrderResponseDto order;

            try
            {
                order = _orderService.GetOrderById(id);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "Buyer")]
        public IActionResult CreateOrder([FromBody] OrderRequestDto requestDto)
        {
            long userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            OrderResponseDto order;

            try
            {
                order = _orderService.CreateOrder(requestDto, userId);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidFieldsException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(order);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Buyer")]
        public IActionResult DeleteOrder(long id)
        {
            long userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            try
            {
                _orderService.CancelOrder(id, userId);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ForbiddenActionException)
            {
                return Forbid();
            }

            return NoContent();
        }
    }
}
