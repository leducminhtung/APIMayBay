using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class HoaDonViewModel
    {
        [Key]
        public Guid MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int SL_NguoiLon { get; set; }
        public int SL_TreEm { get; set; }
        public int SL_EmBe { get; set; }

        public decimal TongTien { get; set; }

        [ForeignKey("KhachViewModel")]
        public Guid MaKhach { get; set; }
        public KhachViewModel Khach { get; set; }

        private ICollection<VeMayBayViewModel> VeMayBays { get; set; }
    }
}
