using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Nhom6_DoAnMonHoc.Models; // Thay thế namespace này bằng namespace chứa ApplicationUser và ChangeRoleViewModel của bạn

namespace Nhom6_DoAnMonHoc.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")] // Thay đổi giá trị này nếu tên role teacher của bạn khác
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private const int PageSize = 5; // Điều chỉnh số lượng người dùng hiển thị trên mỗi trang nếu muốn

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var users = _userManager.Users.OrderBy(u => u.UserName);

            var totalUsers = await users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalUsers / (double)PageSize);

            var paginatedUsers = await users.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;

            return View(paginatedUsers);
        }


    }
}
