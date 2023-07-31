using Microsoft.EntityFrameworkCore;
using Pharmax.Models;

namespace Pharmax.Repository
{
    public class OrderDAL:IOrderRepository
    {
        private readonly PharmacyDbContext _context;

        public OrderDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        #region Get order list
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var records = await _context.Orders.Select(o => new Order()
                {
                    OrderDate = o.OrderDate,
                    OrderId = o.OrderId,
                    Amount = o.Amount,
                    Count = o.Count,
                    IsPickedUp = o.IsPickedUp,

                    Doctor = o.Doctor,
                    DoctorId = o.DoctorId,
                    Drug = o.Drug,
                    DrugId = o.DrugId,
                }).ToListAsync();

                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Get order between the date range given
        public async Task<List<Order>> GetOrdersReport(DateTime From,DateTime To)
        {
            try
            {

                var records = await _context.Orders.Where(o => o.OrderDate >= From && o.OrderDate <= To)
                    .Select(o => new Order()
                    {
                        OrderDate = o.OrderDate,
                        OrderId = o.OrderId,
                        Amount = o.Amount,
                        Count = o.Count,
                        IsPickedUp = o.IsPickedUp,

                        Doctor = o.Doctor,
                        DoctorId = o.DoctorId,
                        Drug = o.Drug,
                        DrugId = o.DrugId,

                    }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Insert order
        public async Task<int> AddOrder(Order order)
        {
            try
            {

                var record = new Order()
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    Amount = order.Amount,
                    Count = order.Count,

                    // Doctor= order.Doctor,
                    DoctorId = 1,
                    DrugId = order.DrugId,



                };

                _context.Orders.Add(record);
                await _context.SaveChangesAsync();
                return record.OrderId;
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
                var ord = await _context.Orders.FindAsync(id);
                if (ord != null)
                {
                    ord.IsPickedUp = true;
                    //ord.OrderDate = order.OrderDate;
                    //ord.Amount = order.Amount;
                    //ord.Count = order.Count;
                    //ord.DoctorId = 1;
                    //ord.OrderId = id;

                };

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Get order confirmation
        public async Task<List<Order>> GetOrdersConfirmation()
        {
            try
            {
                var records = await _context.Orders.Where(o => o.IsPickedUp == true)
                    .Select(o => new Order()
                    {
                        OrderDate = o.OrderDate,
                        OrderId = o.OrderId,
                        Amount = o.Amount,
                        Count = o.Count,
                        IsPickedUp = o.IsPickedUp,

                        Doctor = o.Doctor,
                        DoctorId = o.DoctorId,
                        Drug = o.Drug,
                        DrugId = o.DrugId,
                    }).ToListAsync();

                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
