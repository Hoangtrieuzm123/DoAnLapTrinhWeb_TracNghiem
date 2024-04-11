using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nhom6_DoAnMonHoc.Models;
using Nhom6_DoAnMonHoc.Repositories;

namespace Nhom6_DoAnMonHoc.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class CauHoiController : Controller
    {
        private readonly ICauHoiRepository _CauHoiRepository;
        private readonly IDeThiRepository _DeThiRepository;

        public CauHoiController(ICauHoiRepository cauHoiRepository, IDeThiRepository deThiRepository)
        {
            _CauHoiRepository = cauHoiRepository;
            _DeThiRepository = deThiRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cauhois = await _CauHoiRepository.GetAllAsync();
            return View(cauhois);
        }

        public async Task<IActionResult> Add()
        {
            var dethis = await _DeThiRepository.GetAllAsync();
            ViewBag.Dethis = new SelectList(dethis, "Madt", "Tendt");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                await _CauHoiRepository.AddAsync(cauHoi);
                return RedirectToAction(nameof(Index));
            }
            var dethis = await _DeThiRepository.GetAllAsync();
            ViewBag.DeThi = new SelectList(dethis, "Madt", "Tendt");
            return View(dethis);
        }
        // Hiển thị thông tin chi tiết sản phẩm

        public async Task<IActionResult> Display(int id)
        {
            var cauhoi = await _CauHoiRepository.GetByIdAsync(id);
            if (cauhoi == null)
            {
                return NotFound();
            }
            return View(cauhoi);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var cauhoi = await _CauHoiRepository.GetByIdAsync(id);
            if (cauhoi == null)
            {
                return NotFound();
            }
            var dethi = await _DeThiRepository.GetAllAsync();
            ViewBag.DeThi = new SelectList(dethi, "Madt", "Tendt",
            cauhoi.Mach);
            return View(cauhoi);
        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, CauHoi cauHoi)
        {
            
            if (id != cauHoi.Mach)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingCauHoi = await _CauHoiRepository.GetByIdAsync(id);
                existingCauHoi.Mach = cauHoi.Mach;
                existingCauHoi.Cauhoi = cauHoi.Cauhoi;
                existingCauHoi.DapanA = cauHoi.DapanA;
                existingCauHoi.DapanB = cauHoi.DapanB;
                existingCauHoi.DapanC = cauHoi.DapanC;
                existingCauHoi.DapanD = cauHoi.DapanD;
                await _CauHoiRepository.UpdateAsync(existingCauHoi);
                return RedirectToAction(nameof(Index));
            }
            var dethi = await _DeThiRepository.GetAllAsync();
            ViewBag.DeThi = new SelectList(dethi, "Madt", "Tendt");
            return View(dethi);
        }
        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var cauhoi = await _CauHoiRepository.GetByIdAsync(id);
            if (cauhoi == null)
            {
                return NotFound();
            }
            return View(cauhoi);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _CauHoiRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
