using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMayBay.Models
{
    public class HoaDonInsertModel
    {
        public DateTime NgayLap { get; set; }
        public int SL_NguoiLon { get; set; }
        public int SL_TreEm { get; set; }
        public int SL_EmBe { get; set; }

        public decimal TongTien { get; set; }
      
        public Guid MaKhach { get; set; }
       
    }
}
