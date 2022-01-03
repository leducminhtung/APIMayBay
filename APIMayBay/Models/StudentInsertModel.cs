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

        public decimal GIA { get; set; }

        public DateTime NgayDi { get; set; }
        public DateTime NgayDen { get; set; }

        public int ThoiGianBay { get; set; }
    }
}
