namespace WebTraSua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anh")]
    public partial class Anh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anh()
        {
            NguyenLieux = new HashSet<NguyenLieu>();
            AnhSPs = new HashSet<AnhSP>();
            TinTucs = new HashSet<TinTuc>();
        }

        [Key]
        [Required(ErrorMessage ="Mã ảnh chưa được nhập")]
        [StringLength(30)]
        public string MaA { get; set; }

        [Required(ErrorMessage = "Đường dẫn chưa được nhập")]
        [StringLength(100)]
        public string DuongDan { get; set; }

        public DateTime? ThoiGianA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhSP> AnhSPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
