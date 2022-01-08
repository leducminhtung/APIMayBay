using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IKhachRepository : IRepository<KhachViewModel>
    {
        List<KhachViewModel> GetKhachs();
    }
    public class KhachRepository : RepositoryBase<KhachViewModel>, IKhachRepository
    {
        public KhachRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<KhachViewModel> GetKhachs()
        {
            var query = _dbcontext.Khach.AsQueryable();
            return query.ToList();
        }

    }
}
