using Lib.Entity;
using Lib.Repositories;
using Lib.Repositories.Lib.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class ChuyenBayService
    {
        private IChuyenBayRepository chuyenBayRepository;
        private ApplicationDbContext dbContext;
        public ChuyenBayService(ApplicationDbContext dbContext, IChuyenBayRepository chuyenBayRepository) {
            this.chuyenBayRepository = chuyenBayRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        public List<ChuyenBayViewModel> GetChuyenBays() {
            return chuyenBayRepository.GetChuyenBays();
        }
        public void InsertChuyenBay(ChuyenBayViewModel chuyenbay)
        {
            List<ChuyenBayViewModel> dsCB = GetChuyenBays();
            int dem = 0;
            foreach(var item in dsCB)
            {
                if (item.MaCB.Equals(chuyenbay.MaCB))
                {
                    dem++;
                    chuyenbay.MaCB = item.MaCB;
                    chuyenbay.Id = item.Id;
                    var existingEntity3 = dbContext.ChuyenBay.Find(item.Id);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(chuyenbay);
                    Save();
                    break;
                }
            }

            if (dem > 0) 
            {
                Save();
            } 
            else
            {
                dbContext.Add(chuyenbay); Save();
            }
            
            
        }
        
    }
}
