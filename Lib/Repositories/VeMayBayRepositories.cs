using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IVeMayBayRepository : IRepository<VeMayBayViewModel>
    {
        List<VeMayBayViewModel> GetVeMayBays();
    }
    public class VeMayBayRepository : RepositoryBase<VeMayBayViewModel>, IVeMayBayRepository
    {
        public VeMayBayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<VeMayBayViewModel> GetVeMayBays()
        {
            var query = _dbcontext.VeMayBay.AsQueryable();
            return query.ToList();
        }

    }
}
