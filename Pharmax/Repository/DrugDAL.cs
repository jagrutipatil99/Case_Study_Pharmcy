using Microsoft.EntityFrameworkCore;
using Pharmax.Models;

namespace Pharmax.Repository
{
    public class DrugDAL:IDrugRepository
    {
       
            private readonly PharmacyDbContext _context;

            public DrugDAL(PharmacyDbContext context)
            {
                _context = context;
            }
        #region Get Drug list
        public async Task<List<Drug>> GetAllDrugs()
            {
            try
            {
                var records = await _context.Drugs.Select(x => new Drug()
                {
                    DrugId = x.DrugId,
                    DrugName = x.DrugName,
                    ExpDate = x.ExpDate,
                    Price = x.Price,
                    Stock = x.Stock,
                    Image = x.Image,

                }).ToListAsync();
                return records;
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
                var records = await _context.Drugs.Where(x => x.DrugName == DrugName).Select(x => new Drug()
                {
                    DrugId = x.DrugId,
                    DrugName = x.DrugName,
                    ExpDate = x.ExpDate,
                    Price = x.Price,
                    Stock = x.Stock,
                    Image = x.Image,

                }).FirstOrDefaultAsync();
                return records;
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
                var med = new Drug()
                {
                    ExpDate = Drug.ExpDate,
                    //DrugId = Drug.DrugId,
                    DrugName = Drug.DrugName,
                    Price = Drug.Price,
                    Stock = Drug.Stock,
                    Image = Drug.Image,

                };
                _context.Drugs.AddAsync(med);
                await _context.SaveChangesAsync();
                return med.DrugId;
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
                var med = await _context.Drugs.FindAsync(id);
                if (med != null)
                {
                    med.Stock = Drug.Stock;
                    med.Price = Drug.Price;
                    med.DrugName = Drug.DrugName;
                    med.ExpDate = Drug.ExpDate;
                    med.Image = Drug.Image;
                };

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        //public async Task UpdateDrugByStock(int id, JsonPatchDocument Drug)
        //{
        //    var med = await _context.Drugs.FindAsync(id);

        //    if (med != null)
        //    {
        //        Drug.ApplyTo(med);
        //        await _context.SaveChangesAsync();

        //    }

        //}
        #region Delete Drug
        public async Task DeleteDrug(int id)
            {
            try
            {
                var med = new Drug() { DrugId = id };
                _context.Drugs.Remove(med);
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
