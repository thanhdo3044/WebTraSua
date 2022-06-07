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
        [Column(Order = 0)]
        [StringLength(30)]
        public string MaSP { get; set; }

        [Column(Order = 1)]
        [StringLength(30)]
        public string MaA { get; set; }

        [Required(ErrorMessage = "Tên ảnh sản phẩm không được bỏ chống")]
        [StringLength(100)]
        public string TenASP { get; set; }

        [StringLength(200)]
        public string urlimg { get; set; }

        [Key]
        [Column(Order = 4)]
        public int id { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
