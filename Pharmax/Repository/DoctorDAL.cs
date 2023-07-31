using Microsoft.EntityFrameworkCore;
using Pharmax.Models;

namespace Pharmax.Repository
{
    public class DoctorDAL:IDoctorRepository
    {
        private readonly PharmacyDbContext _context;

        public DoctorDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        #region Get doctor list
        public async Task<List<Doctor>> GetAllDoctors()
        {
            try
            {
                var records = await _context.Doctors.Select(x => new Doctor()
                {
                    DoctorId = x.DoctorId,
                    DocName = x.DocName,
                    DocEmail = x.DocEmail,
                    DocPhnNum = x.DocPhnNum,
                    DocPassword = x.DocPassword,
                    DocAddress = x.DocAddress,
                    Role = x.Role,

                }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get doctor by name
        public async Task<Doctor> GetDoctorByName(string DocEmail)
        {
            try
            {
                var records = await _context.Doctors.Where(x => x.DocEmail == DocEmail).Select(x => new Doctor()
                {
                    DoctorId = x.DoctorId,
                    DocName = x.DocName,
                    DocEmail = x.DocEmail,
                    DocPhnNum = x.DocPhnNum,
                    DocPassword = x.DocPassword,
                    DocAddress = x.DocAddress,
                    Role = x.Role,

                }).FirstOrDefaultAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Insert doctor
        public async Task<int> AddDoctor(Doctor doctor)
        {
            try
            {
                var doc = new Doctor()
                {
                    //DoctorId = doctor.DoctorId,
                    DocName = doctor.DocName,
                    DocEmail = doctor.DocEmail,
                    DocPhnNum = doctor.DocPhnNum,
                    DocPassword = doctor.DocPassword,
                    DocAddress = doctor.DocAddress,
                    Role = "Doctor",

                };
                _context.Doctors.AddAsync(doc);
                await _context.SaveChangesAsync();
                return doc.DoctorId;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region Delete doctor
        public async Task DeleteDoctor(int id)
        {
            try
            {
                var doc = new Doctor() { DoctorId = id };
                _context.Doctors.Remove(doc);
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
