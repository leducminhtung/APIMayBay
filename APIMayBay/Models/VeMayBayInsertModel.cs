using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMayBay.Models
{
    public class VeMayBayInsertModel
    {
        public Guid Id { get; set; }
        public Guid MaHD { get; set; }

        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string LoaiVe { get; set; }
    }
}
