namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
            BinhLuans = new HashSet<BinhLuan>();
            AnhSPs = new HashSet<AnhSP>();
        }

        [Key]
        [Required(ErrorMessage ="Mã sản phẩm chưa được nhập")]
        [StringLength(30)]
        [Display(Name = "Mã sản phẩm")]
        public string MaSP { get; set; }
        

        [Required]
        [StringLength(30)]
        [Display(Name = "Mã danh mục")]
        public string MaDM { get; set; }
       

        [Required(ErrorMessage ="Tên sản phẩm chưa được nhập")]
        [StringLength(200)]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
       

        [StringLength(500)]
        [Display(Name = "Mô tả sản phẩm")]
        public string MotaSP { get; set; }
        
        [Required(ErrorMessage ="Giá sản phẩm chưa được nhập")]
        [Display(Name = "Giá")]
        public int? GiaBanSP { get; set; }
        

        [StringLength(200)]
        [Display(Name = "Chi tiết")]
        public string ChiTietSP { get; set; }
        

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThaiSP { get; set; }

        [Display(Name = "Khuyễn mãi")]
        public DateTime? KhuyenMaiSP { get; set; }
        

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhSP> AnhSPs { get; set; }
    }
}
