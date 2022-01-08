using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IHoaDonRepository : IRepository<HoaDonViewModel>
    {
        List<HoaDonViewModel> GetHoaDons();
    }
    public class HoaDonRepository : RepositoryBase<HoaDonViewModel>, IHoaDonRepository
    {
        public HoaDonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<HoaDonViewModel> GetHoaDons()
        {
            var query = _dbcontext.HoaDon.AsQueryable();
            return query.ToList();
        }

    }

}
