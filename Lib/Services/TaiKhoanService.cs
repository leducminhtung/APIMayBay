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
    public class TaiKhoanService
    {
        private ITaiKhoanRepository taiKhoanRepository;
        private ApplicationDbContext dbContext;
        public TaiKhoanService(ApplicationDbContext dbContext, ITaiKhoanRepository taiKhoanRepository)
        {
            this.taiKhoanRepository = taiKhoanRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<TaiKhoanViewModel> GetTaiKhoans()
        {
            return taiKhoanRepository.GetTaiKhoans();
        }
        public void InsertTaiKhoan(TaiKhoanViewModel taikhoan)
        {
            List<TaiKhoanViewModel> dsCB = GetTaiKhoans();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.MaTK.Equals(taikhoan.MaTK))
                {
                    dem++;
                    taikhoan.MaTK = item.MaTK;
               
                    var existingEntity3 = dbContext.TaiKhoan.Find(item.MaTK);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(taikhoan);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(taikhoan); Save();
            }


        }

    }
}
