using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmax.Models;
using Pharmax.Repository;
using Pharmax.Services;

namespace Pharmax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly OrderServices _orderServices;

        public OrdersController(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        #region Get Order list
        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderServices.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert order
      
        [HttpPost("")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                var id = await _orderServices.AddOrder(order);
                return CreatedAtAction(nameof(AddOrder), id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get order between date range 
        [HttpGet("From/{From}/To/{To}")]
        public async Task<IActionResult> GetOrdersReport([FromRoute] DateTime From, [FromRoute] DateTime To)
        {
            try
            {
                var orders = await _orderServices.GetOrdersReport(From, To);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update order
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order, [FromRoute] int id)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _orderServices.UpdateOrder(id, order);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get order confirmation
        [HttpGet("confirmation")]
        public async Task<IActionResult> GetOrdersConfirmation()
        {
            try
            {
                var orders = await _orderServices.GetOrdersConfirmation();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}