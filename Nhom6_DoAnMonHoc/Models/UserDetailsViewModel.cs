﻿namespace Nhom6_DoAnMonHoc.Models
{
    public class UserDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
