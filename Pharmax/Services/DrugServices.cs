using Microsoft.EntityFrameworkCore;
using Pharmax.Models;
using Pharmax.Repository;

namespace Pharmax.Services
{
    public class DrugServices 
    {
        IDrugRepository _Drug;
        public DrugServices(IDrugRepository Drug)
        {
            try
            {
                _Drug = Drug;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get Drug list
        public async Task<List<Drug>> GetAllDrugs()
        {
            try
            {
                return await _Drug.GetAllDrugs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Get Drug by name
        public async Task<Drug> GetDrugByName(string DrugName)
        {
            try
            {
                return await _Drug.GetDrugByName(DrugName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert Drug
        public async Task<int> AddDrug(Drug Drug)
        {
            try
            {
                return await _Drug.AddDrug(Drug);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update Drug
        public async Task UpdateDrug(int id, Drug Drug)
        {
            try
            {
                await _Drug.UpdateDrug(id, Drug);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Delete Drug
        public async Task DeleteDrug(int id)
        {
            try
            {
                await _Drug.DeleteDrug(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
