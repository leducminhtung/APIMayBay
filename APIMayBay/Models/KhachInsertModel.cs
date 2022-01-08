using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMayBay.Models
{
    public class KhachInsertModel
    {
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }

        public string Email { get; set; }

        public string SDT { get; set; }
    }
}
