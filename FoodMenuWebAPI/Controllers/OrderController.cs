using FoodMenuWebAPI.Model;
using FoodMenuWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]       
        public ActionResult<List<Order>> GetAllOrders()
        {
            try
            {
                return Ok(_orderService.RetriveAllOrdersForCustomer());
            }
            catch (Exception ex)
            {               
                return NotFound("Order not found");
            }
        }

        [HttpGet("{orderId}")]       
        public ActionResult<Order> GetOrderById(int orderId)
        {
            try
            {
                return Ok(_orderService.RetriveSpecificOrderDetails(orderId));
            }
            catch (Exception ex)
            {               
                return NotFound("Order not found");
            }
        }

        [HttpPost]        
        public ActionResult<string> CreateOrder(Order order)
        {
            try
            {
                _orderService.PlaceOrder(order);
                return StatusCode(201, "Order Placed");
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
       
        public ActionResult<string> ModifyOrder(Order order)
        {
            try
            {
                _orderService.ModifyOrder(order);
                return Ok("Order Modified");
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]       
        public ActionResult<string> ModifyFoodQuantity(int orderid, int quantity)
        {
            try
            {
                _orderService.ModifyFoodQuantityInOrder(orderid, quantity);
                return Ok("Quantity for the order has been Modifued");
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
       
        public ActionResult<string> CancelOrder(int orderid)
        {
            try
            {
                _orderService.CancelOrder(orderid);
                return Ok("Order has cancelled");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

    }
}

