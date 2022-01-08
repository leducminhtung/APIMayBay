using Lib.Data;
using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoanViewModel>
    {
        List<TaiKhoanViewModel> GetTaiKhoans();
    }
    public class TaiKhoanRepository : RepositoryBase<TaiKhoanViewModel>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<TaiKhoanViewModel> GetTaiKhoans()
        {
            var query = _dbcontext.TaiKhoan.AsQueryable();
            return query.ToList();
        }

    }
}
