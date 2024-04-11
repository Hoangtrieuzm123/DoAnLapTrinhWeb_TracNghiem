using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nhom6_DoAnMonHoc.Models
{
    public class CauHoi
    {
        [Key]
        public int Mach { get; set; }
        [Required, StringLength(20)]
        public int Madt { get; set; }
        [Required, StringLength(300)]
        public string Cauhoi { get; set; }
        [StringLength(300)]
        public string DapanA { get; set; }
        [StringLength(300)]
        public string DapanB { get; set; }
        [StringLength(300)]
        public string DapanC { get; set; }
        [StringLength(300)]
        public string DapanD { get; set; }
        [Required]
        public string Dapan { get; set; }
        public DeThi? DeThi { get; set; }
    }
}
