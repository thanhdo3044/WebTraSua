namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(30)]
        [Display(Name = "Mã danh mục")]
        public string MaDM { get; set; }
        

        [StringLength(200)]
        [Display(Name = "Tên danh mục")]
        public string TenDM { get; set; }
        

        [StringLength(200)]
        [Display(Name = "Mô tả danh mục")]
        public string MotaDM { get; set; }
        

        [Display(Name = "Ngày tạo")]
        public DateTime? NgayTao { get; set; }
        

        [StringLength(200)]
        [Display(Name = "Trang thái")]
        public string TrangThaiDM { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
