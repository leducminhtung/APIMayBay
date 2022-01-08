using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ILoTuyenRepository : IRepository<LoTuyenViewModel>
    {
        List<LoTuyenViewModel> GetLoTuyens();
    }
    public class LoTuyenRepository : RepositoryBase<LoTuyenViewModel>, ILoTuyenRepository
    {
        public LoTuyenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<LoTuyenViewModel> GetLoTuyens()
        {
            var query = _dbcontext.LoTuyen.AsQueryable();
            return query.ToList();
        }

    }
}
