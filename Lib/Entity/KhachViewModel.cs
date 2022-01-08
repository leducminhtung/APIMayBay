using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class KhachViewModel
    {
        [Key]

        public Guid MaKhach { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }

        public string Email { get; set; }

        public string SDT { get; set; }

        private ICollection<HoaDonViewModel> HoaDon { get; set; }

    }
}
