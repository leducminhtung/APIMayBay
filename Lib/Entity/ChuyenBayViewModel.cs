using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class ChuyenBayViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string MaCB { get; set; }
        public string TenMB { get; set; }
        public string MACANGDI { get; set; }
        public string TENCANGDI { get; set; }
        public string PICTURE { get; set; }
        public string TENHANG { get; set; }
        public string MACANGDEN { get; set; }
        public string TENCANGDEN { get; set; }

        public decimal GIANGUOILON { get; set; }
        public decimal GIATREEM { get; set; }
        public decimal GIAEMBE { get; set; }

        public decimal THUEPHISANBAYNGUOILON { get; set; }
        public decimal THUEPHISANBAYTREEM { get; set; }
        public decimal THUEPHISANBAYEMBE { get; set; }

        public decimal GIADICHVUNGUOILON { get; set; }
        public decimal GIADICHVUTREEM { get; set; }
        public decimal GIADICHVUEMBE { get; set; }

        public decimal TONGTIEN { get; set; }

        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongEmBe { get; set; }

        public string NgayDi { get; set; }
        public string NgayDen { get; set; }
        public string GioDi { get; set; }
        public string GioDen { get; set; }

        public DateTime NgayGioDi { get; set; }
        public DateTime NgayGioDen { get; set; }

        public int ThoiGianBay { get; set; }

        private ICollection<VeMayBayViewModel> Ve { get; set; }
        private ICollection<LoTuyenViewModel> LoTuyen { get; set; }

        public ChuyenBayViewModel()
        {
            Id = new Guid();
            MaCB = "";
            TenMB = "";
            MACANGDI = "";
            TENCANGDI = "";
            PICTURE = "";
            TENHANG = "";
            MACANGDEN = "";
            TENCANGDEN = "";
            NgayDi = "";
            NgayDen = "";
            GioDi = "";
            GioDen = "";
            GIANGUOILON = 0;
            GIATREEM = 0;
            GIAEMBE = 0;
            THUEPHISANBAYNGUOILON = 0;
            THUEPHISANBAYTREEM = 0;
            THUEPHISANBAYEMBE = 0;
            GIADICHVUNGUOILON = 0;
            GIADICHVUTREEM = 0;
            GIADICHVUEMBE = 0;
            TONGTIEN = 0;
            NgayGioDi = DateTime.Now;
            NgayGioDen = DateTime.Now;
            ThoiGianBay = 0;
            SoLuongNguoiLon = 0;
            SoLuongTreEm = 0;
            SoLuongEmBe = 0;
        }
        public ChuyenBayViewModel(Guid id, string maCB, string tenMB, string mACANGDI, string tENCANGDI, string pICTURE, string tENHANG, string mACANGDEN, string tENCANGDEN, decimal gIANGUOILON, decimal gIATREEM, decimal gIAEMBE, decimal tHUEPHISANBAYNGUOILON, decimal tHUEPHISANBAYTREEM, decimal tHUEPHISANBAYEMBE, decimal gIADICHVUNGUOILON, decimal gIADICHVUTREEM, decimal gIADICHVUEMBE, decimal tONGTIEN, DateTime ngayGioDi, DateTime ngayGioDen, int thoiGianBay, int soLuongNguoiLon,int soLuongTreEm,int soLuongEmBe,string ngayDi,string ngayDen, string gioDi,string gioDen)
        {
            Id = id;
            MaCB = maCB;
            TenMB = tenMB;
            MACANGDI = mACANGDI;
            TENCANGDI = tENCANGDI;
            PICTURE = pICTURE;
            TENHANG = tENHANG;
            MACANGDEN = mACANGDEN;
            TENCANGDEN = tENCANGDEN;
            GIANGUOILON = gIANGUOILON;
            GIATREEM = gIATREEM;
            GIAEMBE = gIAEMBE;
            THUEPHISANBAYNGUOILON = tHUEPHISANBAYNGUOILON;
            THUEPHISANBAYTREEM = tHUEPHISANBAYTREEM;
            THUEPHISANBAYEMBE = tHUEPHISANBAYEMBE;
            GIADICHVUNGUOILON = gIADICHVUNGUOILON;
            GIADICHVUTREEM = gIADICHVUTREEM;
            GIADICHVUEMBE = gIADICHVUEMBE;
            TONGTIEN = tONGTIEN;
            NgayDi = ngayDi;
            NgayDen = ngayDen;
            GioDi = gioDi;
            GioDen = gioDen;
            NgayGioDi = ngayGioDi;
            NgayGioDen = ngayGioDen;
            ThoiGianBay = thoiGianBay;
            SoLuongNguoiLon = soLuongNguoiLon;
            SoLuongTreEm = soLuongTreEm;
            SoLuongEmBe = soLuongEmBe;
        }
    }
}
