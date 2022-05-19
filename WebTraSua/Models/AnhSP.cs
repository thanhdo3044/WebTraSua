namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnhSP")]
    public partial class AnhSP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string MaA { get; set; }

        [StringLength(100)]
        public string TenASP { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
