using Microsoft.EntityFrameworkCore;
using Pharmax.Models;
using Pharmax.Repository;

namespace Pharmax.Services
{
    public class DoctorServices
    {
         IDoctorRepository _doctor;

        public DoctorServices(IDoctorRepository doctor)
        {
            try
            {
                _doctor = doctor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get Doctors List
        public async Task<List<Doctor>> GetAllDoctors()
        {
            try
            {
                return await _doctor.GetAllDoctors();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get Doctor by emailID
        public async Task<Doctor> GetDoctorByName(string DocEmail)
        {
            try
            {
                return await _doctor.GetDoctorByName(DocEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Insert Doctor
        public async Task<int> AddDoctor(Doctor doctor)
        {
            try
            {
                return await _doctor.AddDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Delete Doctor
        public async Task DeleteDoctor(int id)
        {
            try
            {
                await _doctor.DeleteDoctor(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
