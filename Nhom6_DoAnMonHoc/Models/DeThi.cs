using System.ComponentModel.DataAnnotations;

namespace Nhom6_DoAnMonHoc.Models
{
    public class DeThi
    {
        [Key]
        public int Madt { get; set; }

        [Required, StringLength(50)]
        public string Tendt { get; set; }

        [Range(1, 420)]
        public int Thoigianthi { get; set; }
        public int Soluongcauhoi { get; set; }
        [StringLength(100)]
        public string Mota { get; set; }
        
        // Mối quan hệ 1-n với CauHoi: Một DeThi có nhiều CauHoi
        public List<CauHoi> CauHois { get; set; }
    }
}
