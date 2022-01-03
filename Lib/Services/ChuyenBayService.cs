using Lib.Entity;
using Lib.Repositories;
using Lib.Repositories.Lib.Repositories;
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
        public void InsertStudent(ChuyenBayViewModel student)
        {
            dbContext.Add(student);
            Save();
        }
        
    }
}
