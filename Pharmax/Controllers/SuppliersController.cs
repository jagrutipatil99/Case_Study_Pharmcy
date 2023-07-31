using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmax.Models;
using Pharmax.Repository;
using Pharmax.Services;

namespace Pharmax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public readonly SupplierServices _supplierServices;
        public SuppliersController(SupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }
        #region Get supplier list
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _supplierServices.GetAllSuppliers();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert supplier
        [HttpPost("")]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            try
            {
                var id = await _supplierServices.AddSupplier(supplier);
                return CreatedAtAction(nameof(AddSupplier), id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Update supplier
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supplier, [FromRoute] int id)
        {
            try
            {
                if (id != supplier.SupplierId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _supplierServices.UpdateSupplier(id, supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Delete Supplier
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
        {
            try
            {
                await _supplierServices.DeleteSupplier(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
