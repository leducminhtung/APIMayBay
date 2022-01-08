using Lib.Entity;
using Lib.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lib
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ChuyenBayViewModel> ChuyenBay { get; set; }
        public DbSet<CangBayViewModel> CangBay { get; set; }

        public DbSet<HoaDonViewModel> HoaDon { get; set; }

        public DbSet<KhachViewModel> Khach { get; set; }

        public DbSet<LoTuyenViewModel> LoTuyen { get; set; }

        public DbSet<TaiKhoanViewModel> TaiKhoan { get; set; }

        public DbSet<VeMayBayViewModel> VeMayBay { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
