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
    public class VeMayBayService
    {
        private IVeMayBayRepository veMayBayRepository;
        private ApplicationDbContext dbContext;
        public VeMayBayService(ApplicationDbContext dbContext, IVeMayBayRepository veMayBayRepository)
        {
            this.veMayBayRepository = veMayBayRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<VeMayBayViewModel> GetVeMayBays()
        {
            return veMayBayRepository.GetVeMayBays();
        }
        public void InsertVeMayBay(VeMayBayViewModel vemaybay)
        {
            List<VeMayBayViewModel> dsCB = GetVeMayBays();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.STT.Equals(vemaybay.STT))
                {
                    dem++;
                    vemaybay.STT = item.STT;
                 
                    var existingEntity3 = dbContext.VeMayBay.Find(item.STT);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(vemaybay);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(vemaybay); Save();
            }


        }

    }
}
