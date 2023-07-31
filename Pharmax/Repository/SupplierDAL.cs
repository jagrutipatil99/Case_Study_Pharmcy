using Microsoft.EntityFrameworkCore;
using Pharmax.Models;

namespace Pharmax.Repository
{
    public class SupplierDAL:ISupplierRepository
    {
        private readonly PharmacyDbContext _context;

        public SupplierDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        #region Get supplier list
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                var records = await _context.Suppliers.Select(x => new Supplier()
                {
                    SupplierId = x.SupplierId,
                    SupplierName = x.SupplierName,
                    SupplierEmail = x.SupplierEmail,
                    SupplierPhnNum = x.SupplierPhnNum,
                    DrugId = x.DrugId,
                    Drug = x.Drug,



                }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert a new supplier
        public async Task<int> AddSupplier(Supplier supplier)
        {
            try
            {
                var x = new Supplier()
                {
                    SupplierId = supplier.SupplierId,
                    SupplierName = supplier.SupplierName,
                    SupplierEmail = supplier.SupplierEmail,
                    SupplierPhnNum = supplier.SupplierPhnNum,
                    DrugId = supplier.DrugId,


                };
                _context.Suppliers.Add(x);
                await _context.SaveChangesAsync();
                return x.SupplierId;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region Update supplier
        public async Task UpdateSupplier(int id, Supplier supplier)
        {
            try
            {
                var x = await _context.Suppliers.FindAsync(id);
                if (x != null)
                {
                    x.SupplierId = supplier.SupplierId;
                    x.SupplierName = supplier.SupplierName;
                    x.SupplierEmail = supplier.SupplierEmail;
                    x.SupplierPhnNum = supplier.SupplierPhnNum;
                    x.DrugId = supplier.DrugId;

                };

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Delete supplier

        public async Task DeleteSupplier(int id)
        {
            try
            {
                var supplier = new Supplier() { SupplierId = id };
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
