using Microsoft.EntityFrameworkCore;
using Nhom6_DoAnMonHoc.Models;

namespace Nhom6_DoAnMonHoc.Repositories
{
    public class EFDeThiRepository : IDeThiRepository
    {
        private readonly ApplicationDbContext _context;
        public EFDeThiRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DeThi>> GetAllAsync()
        {
            return await _context.DeThis.Include(p => p.CauHois).ToListAsync();
        }
        public async Task<DeThi> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.DeThis.Include(p => p.CauHois).FirstOrDefaultAsync(p => p.Madt == id);
        }
        public async Task AddAsync(DeThi deThi)
        {
            _context.DeThis.Add(deThi);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(DeThi deThi)
        {
            _context.DeThis.Update(deThi);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var deThi = await _context.DeThis.FindAsync(id);
            _context.DeThis.Remove(deThi);
            await _context.SaveChangesAsync();
        }
    }
}
