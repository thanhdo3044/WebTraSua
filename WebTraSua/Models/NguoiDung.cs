namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
            NguyenLieux = new HashSet<NguyenLieu>();
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        [StringLength(30)]
        public string MaND { get; set; }
        [Display(Name = "Mã người dùng")]

        [StringLength(200)]
        public string HoTenND { get; set; }
        [Display(Name = "Họ tên")]

        [StringLength(5)]
        public string GioiTinhND { get; set; }
        [Display(Name = "Giới tính")]

        [StringLength(200)]
        public string EmailND { get; set; }
        [Display(Name = "Email")]

        [StringLength(200)]
        public string SoDienThoaiND { get; set; }
        [Display(Name = "Số điện thoại")]

        [StringLength(200)]
        public string DiaChiND { get; set; }
        [Display(Name = "Địa chỉ")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
