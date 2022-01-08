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
    public class LoTuyenService
    {
        private ILoTuyenRepository loTuyenRepository;
        private ApplicationDbContext dbContext;
        public LoTuyenService(ApplicationDbContext dbContext, ILoTuyenRepository loTuyenRepository)
        {
            this.loTuyenRepository = loTuyenRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<LoTuyenViewModel> GetLoTuyens()
        {
            return loTuyenRepository.GetLoTuyens();
        }
        public void InsertLoTuyen(LoTuyenViewModel lotuyen)
        {
            List<LoTuyenViewModel> dsCB = GetLoTuyens();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.Id.Equals(lotuyen.Id))
                {
                    dem++;
                    lotuyen.Id = item.Id;
                    var existingEntity3 = dbContext.LoTuyen.Find(item.Id);
                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(lotuyen);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(lotuyen); Save();
            }


        }

    }
}
