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
   
    public class DoctorsController : ControllerBase
    {
        public readonly DoctorServices _doctorServices;
        public DoctorsController(DoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }
        #region Get doctor list
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorServices.GetAllDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get doctor by email
        [HttpGet("{DocEmail}")]
        public async Task<IActionResult> GetDoctor([FromRoute] string DocEmail)
        {
            try
            {
                var doctor = await _doctorServices.GetDoctorByName(DocEmail);
                if (!ModelState.IsValid)
                {
                    return BadRequest(doctor);
                }

                if (doctor == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(doctor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert doctor
        [HttpPost("")]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            try
            {
                var id = await _doctorServices.AddDoctor(doctor);
                return CreatedAtAction(nameof(AddDoctor), id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Delete doctor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            try
            {
                await _doctorServices.DeleteDoctor(id);
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
