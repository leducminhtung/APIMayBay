namespace WinformGetJsonMaybay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuyenBay")]
    public partial class ChuyenBay
    {
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

        [Column(TypeName = "datetime2")]
        public DateTime NgayDi { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayDen { get; set; }

        public int ThoiGianBay { get; set; }
    }
}
