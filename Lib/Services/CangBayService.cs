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
    public class CangBayService
    {
        private ICangBayRepository cangBayRepository;
        private ApplicationDbContext dbContext;
        public CangBayService(ApplicationDbContext dbContext, ICangBayRepository cangBayRepository)
        {
            this.cangBayRepository = cangBayRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<CangBayViewModel> GetCangBays()
        {
            return cangBayRepository.GetCangBays();
        }
        public void InsertCangBay(CangBayViewModel cangbay)
        {
            List<CangBayViewModel> dsCB = GetCangBays();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.MaCB.Equals(cangbay.MaCB))
                {
                    dem++;
                    cangbay.MaCB = item.MaCB;
                    cangbay.Id = item.Id;
                    var existingEntity3 = dbContext.CangBay.Find(item.Id);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(cangbay);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(cangbay); Save();
            }


        }

    }
}
