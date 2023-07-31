using Pharmax.Models;

namespace Pharmax.Repository
{
    public interface IDrugRepository
    {
        Task<List<Drug>> GetAllDrugs();
        Task<Drug> GetDrugByName(string DrugName);
        Task<int> AddDrug(Drug Drug);
        Task UpdateDrug(int id, Drug Drug);
        //Task UpdateDrugByStock(int id, JsonPatchDocument Drug);
        Task DeleteDrug(int id);
    }
}
