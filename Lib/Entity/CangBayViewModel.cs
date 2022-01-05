using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class CangBayViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string MaCB { get; set; }
        public string TenMB { get; set; }

        public CangBayViewModel(Guid id, string maCB, string tenMB)
        {
            Id = id;
            MaCB = maCB;
            TenMB = tenMB;
        }
    }
}
