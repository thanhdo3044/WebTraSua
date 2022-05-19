namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        [StringLength(30)]
        public string MaHD { get; set; }
        [Display(Name = "Mã hóa đơn")]

        [Required]
        [StringLength(30)]
        public string MaND { get; set; }

        [StringLength(200)]
        public string TenHD { get; set; }
        [Display(Name = "Tên hóa đơn")]

        public DateTime? ThoiGianHD { get; set; }
        [Display(Name = "Thời gian")]

        [StringLength(200)]
        public string TrangThaiHD { get; set; }
        [Display(Name = "Trạng thái")]

        [StringLength(200)]
        public string DiaChiaHD { get; set; }
        [Display(Name = "Địa chỉ")]

        [StringLength(200)]
        public string SoDienThoaiHD { get; set; }
        [Display(Name = "Số điện thoại")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
