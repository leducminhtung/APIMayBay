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

        public decimal GIA { get; set; }

        public DateTime NgayDi { get; set; }
        public DateTime NgayDen { get; set; }

        public int ThoiGianBay { get; set; }

    }
}
