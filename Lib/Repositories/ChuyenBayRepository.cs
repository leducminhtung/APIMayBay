using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    namespace Lib.Repositories
    {
        public interface IChuyenBayRepository : IRepository<ChuyenBayViewModel>
        {
            List<ChuyenBayViewModel> GetChuyenBays();
        }
        public class ChuyenBayRepository : RepositoryBase<ChuyenBayViewModel>, IChuyenBayRepository
        {
            public ChuyenBayRepository(ApplicationDbContext dbContext) : base(dbContext)
            {
            }
            public List<ChuyenBayViewModel> GetChuyenBays()
            {
                var query = _dbcontext.ChuyenBay.AsQueryable();
                return query.ToList();
            }

        }

        
    }

}
