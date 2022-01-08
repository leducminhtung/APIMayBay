using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class LoTuyenViewModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CangBayViewModel")]
        public Guid Id1 { get; set; }
        public CangBayViewModel CangDi { get; set; }

        public string MaCangDi { get; set; }

        [ForeignKey("CangBayViewModel")]
        public Guid Id2 { get; set; }
        public CangBayViewModel CangDen { get; set; }
        public string MaCangDen { get; set; }
    }
}
