using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmax.Models;
using Pharmax.Repository;
using Pharmax.Services;

namespace Pharmax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DrugsController : ControllerBase
    {
        public readonly DrugServices _DrugServices;
        public DrugsController(DrugServices DrugServices)
        {
            _DrugServices = DrugServices;
        }
        #region Get Drug list
        [HttpGet]
        public async Task<IActionResult> GetAllDrugs()
        {
            try
            {
                var Drugs = await _DrugServices.GetAllDrugs();
                return Ok(Drugs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get Drug by name
        [HttpGet("{DrugName}")]
        public async Task<IActionResult> GetDrug([FromRoute] string DrugName)
        {
            try
            {
                var medcine = await _DrugServices.GetDrugByName(DrugName);
                if (!ModelState.IsValid)
                {
                    return BadRequest(medcine);
                }

                if (medcine == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(medcine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert Drug
        [HttpPost("")]
        public async Task<IActionResult> AddDrug([FromBody] Drug Drug)
        {
            try
            {
                var id = await _DrugServices.AddDrug(Drug);
                return CreatedAtAction(nameof(AddDrug), id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Update Drug
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrug([FromBody] Drug Drug, [FromRoute] int id)
        {
            try
            {
                if (id != Drug.DrugId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _DrugServices.UpdateDrug(id, Drug);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        
        #region Delete Drug
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrug([FromRoute] int id)
        {
            try
            {
                await _DrugServices.DeleteDrug(id);
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
