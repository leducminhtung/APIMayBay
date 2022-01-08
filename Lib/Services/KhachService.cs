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
    public class KhachService
    {
        private IKhachRepository khachRepository;
        private ApplicationDbContext dbContext;
        public KhachService(ApplicationDbContext dbContext, IKhachRepository khachRepository)
        {
            this.khachRepository = khachRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<KhachViewModel> GetKhachs()
        {
            return khachRepository.GetKhachs();
        }
        public void InsertKhach(KhachViewModel khach)
        {
            List<KhachViewModel> dsCB = GetKhachs();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.MaKhach.Equals(khach.MaKhach))
                {
                    dem++;
                    khach.MaKhach = item.MaKhach;
              
                    var existingEntity3 = dbContext.Khach.Find(item.MaKhach);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(khach);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(khach); Save();
            }


        }

    }
}
