using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nhom6_DoAnMonHoc.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Age { get; set; }

    }
}
