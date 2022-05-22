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
        [Required(ErrorMessage = "Mã nguyên liệu chưa được nhập")]
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

        [Required(ErrorMessage = "Số lượng chưa được nhập")]
        public int? SoLuong { get; set; }

        [Required(ErrorMessage = "Chất lượng chưa được nhập")]
        [StringLength(30)]
        public string ChatLuong { get; set; }

        [Required(ErrorMessage = "Giá mua chưa được nhập")]
        public double? GiaMua { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
