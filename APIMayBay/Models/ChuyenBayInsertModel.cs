using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMayBay.Models
{
    public class ChuyenBayInsertModel
    {
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

        public DateTime NgayDi { get; set; }
        public DateTime NgayDen { get; set; }

        public int ThoiGianBay { get; set; }

        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongEmBe { get; set; }
    }
}
