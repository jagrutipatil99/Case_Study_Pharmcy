using Microsoft.EntityFrameworkCore;
using Pharmax.Models;
using Pharmax.Repository;

namespace Pharmax.Services
{
    public class OrderServices
    {
        IOrderRepository _order;
        public OrderServices(IOrderRepository order)
        {
            try
            {
                _order = order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get Order list
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                return await _order.GetAllOrders();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert Order
        public async Task<int> AddOrder(Order order)
        {
            try
            {
                return await _order.AddOrder(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get Order between the range of date given
        public async Task<List<Order>> GetOrdersReport(DateTime From, DateTime To)
        {
            try
            {
                return await _order.GetOrdersReport(From, To);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update order
        public async Task UpdateOrder(int id, Order order)
        {
            try
            {
                await _order.UpdateOrder(id, order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get Order Confirmation
        public async Task<List<Order>> GetOrdersConfirmation()
        {
            try
            {
                return await _order.GetOrdersConfirmation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
