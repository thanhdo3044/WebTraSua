namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [Key]
        [StringLength(30)]
        public string MaNL { get; set; }

        [Required]
        [StringLength(30)]
        public string MaA { get; set; }

        [Required]
        [StringLength(30)]
        public string MaND { get; set; }

        [StringLength(100)]
        public string TenNL { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(30)]
        public string ChatLuong { get; set; }

        public double? GiaMua { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
