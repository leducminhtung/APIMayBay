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
    public class HoaDonService
    {
        private IHoaDonRepository hoaDonRepository;
        private ApplicationDbContext dbContext;
        public HoaDonService(ApplicationDbContext dbContext, IHoaDonRepository hoaDonRepository)
        {
            this.hoaDonRepository = hoaDonRepository;
            this.dbContext = dbContext;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<HoaDonViewModel> GetHoaDons()
        {
            return hoaDonRepository.GetHoaDons();
        }
        public void InsertHoaDon(HoaDonViewModel hoadon)
        {
            List<HoaDonViewModel> dsCB = GetHoaDons();
            int dem = 0;
            foreach (var item in dsCB)
            {
                if (item.MaHD.Equals(hoadon.MaHD))
                {
                    dem++;
                    hoadon.MaHD = item.MaHD;
                    var existingEntity3 = dbContext.HoaDon.Find(item.MaHD);

                    dbContext.Entry(existingEntity3).CurrentValues.SetValues(hoadon);
                    Save();
                }
            }

            if (dem > 0)
            {


                Save();

            }
            else
            {
                dbContext.Add(hoadon); Save();
            }


        }

    }
}
