using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom6_DoAnMonHoc.Models;
using Nhom6_DoAnMonHoc.Repositories;
using System.Threading.Tasks;

namespace Nhom6_DoAnMonHoc.Controllers
{
    public class DeThiController : Controller
    {
        private readonly IDeThiRepository _DeThiRepository;
        private readonly ApplicationDbContext _context;


        public DeThiController(IDeThiRepository deThiRepository, ApplicationDbContext context)
        {
            _DeThiRepository = deThiRepository;
            _context = context;
        }

        // Hiển thị danh sách đề thi
        public async Task<IActionResult> Index()
        {
            var deThis = await _DeThiRepository.GetAllAsync();
            return View(deThis);
        }

        public async Task<IActionResult> Display(int id)
        {
            var dethi = await _DeThiRepository.GetByIdAsync(id);
            if (dethi == null)
            {
                return NotFound();
            }
            return View(dethi);
        }

        // Hiển thị form thêm mới đề thi
        public IActionResult Add()
        {
            return View();
        }

        // Xử lý thêm mới đề thi
        [HttpPost]
        public async Task<IActionResult> Add(DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                await _DeThiRepository.AddAsync(deThi);
                return RedirectToAction(nameof(Index));
            }
            return View(deThi);
        }

        // Hiển thị form cập nhật thông tin đề thi
        public async Task<IActionResult> Update(int id)
        {
            var deThi = await _DeThiRepository.GetByIdAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }
            return View(deThi);
        }

        // Xử lý cập nhật thông tin đề thi
        [HttpPost]
        public async Task<IActionResult> Update(int id, DeThi deThi)
        {
            if (id != deThi.Madt)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _DeThiRepository.UpdateAsync(deThi);
                return RedirectToAction(nameof(Index));
            }
            return View(deThi);
        }

        // Hiển thị form xác nhận xóa đề thi
        public async Task<IActionResult> Delete(int id)
        {
            var deThi = await _DeThiRepository.GetByIdAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }
            return View(deThi);
        }

        // Xử lý xóa đề thi
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _DeThiRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Lam bai thi
        public async Task<IActionResult> TakeExam(int id)
        {
            var exam = await _context.DeThis
                                     .Include(d => d.CauHois)
                                     .FirstOrDefaultAsync(d => d.Madt == id);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

    }
}
