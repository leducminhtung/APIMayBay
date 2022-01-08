using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class TaiKhoanViewModel
    {
        [Key]
        public Guid MaTK { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        
    }
}
