namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [Required(ErrorMessage = "Mã tin tức chưa được nhập")]
        [StringLength(30)]
        public string MaTT { get; set; }

        [Required]
        [StringLength(30)]
        public string MaA { get; set; }

        [Required(ErrorMessage = "Nội dung tin tức chưa được nhập")]
        [StringLength(500)]
        public string NoiDungTT { get; set; }

        [Required(ErrorMessage = "Thời gian chưa được nhập")]
        public DateTime? ThoiGianTT { get; set; }

        [StringLength(200)]
        public string TieuDeTT { get; set; }

        [StringLength(200)]
        public string MotaTT { get; set; }

        public virtual Anh Anh { get; set; }
    }
}
