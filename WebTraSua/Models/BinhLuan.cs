namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string MaND { get; set; }

        [StringLength(300)]
        public string NoiDungBL { get; set; }

        [StringLength(100)]
        public string TrangThaiBL { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
