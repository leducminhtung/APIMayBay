using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class VeMayBayViewModel
    {
        [Key]
        public int STT { get; set; }

        [ForeignKey("ChuyenBayViewModel")]
        public Guid Id { get; set; }
        public ChuyenBayViewModel ChuyenBay { get; set; }

        [ForeignKey("HoaDonViewModel")]
        public Guid MaHD { get; set; }
        public HoaDonViewModel HoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string LoaiVe { get; set; }

        
     
    }
}
