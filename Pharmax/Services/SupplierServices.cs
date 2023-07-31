using Microsoft.EntityFrameworkCore;
using Pharmax.Models;
using Pharmax.Repository;

namespace Pharmax.Services
{
    public class SupplierServices
    {
        ISupplierRepository _supplier;
        public SupplierServices(ISupplierRepository supplier)
        {
            try
            {
                _supplier = supplier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get Supplier List
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                return await _supplier.GetAllSuppliers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert Supplier
        public async Task<int> AddSupplier(Supplier supplier)
        {
            try
            {
                return await _supplier.AddSupplier(supplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update Supplier
        public async Task UpdateSupplier(int id, Supplier supplier)
        {
            try
            {
                await _supplier.UpdateSupplier(id, supplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Delete Supplier
        public async Task DeleteSupplier(int id)
        {
            try
            {
                await _supplier.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
