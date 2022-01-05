using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ICangBayRepository : IRepository<CangBayViewModel>
    {
        List<CangBayViewModel> GetCangBays();
    }
    public class CangBayRepository : RepositoryBase<CangBayViewModel>, ICangBayRepository
    {
        public CangBayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<CangBayViewModel> GetCangBays()
        {
            var query = _dbcontext.CangBay.AsQueryable();
            return query.ToList();
        }

    }

}
