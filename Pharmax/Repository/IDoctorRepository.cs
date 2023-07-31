using Pharmax.Models;

namespace Pharmax.Repository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorByName(string DocEmail);
        Task<int> AddDoctor(Doctor doctor);
        Task DeleteDoctor(int id);
    }
}
