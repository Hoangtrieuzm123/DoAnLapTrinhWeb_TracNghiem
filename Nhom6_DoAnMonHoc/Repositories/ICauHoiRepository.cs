using Nhom6_DoAnMonHoc.Models;

namespace Nhom6_DoAnMonHoc.Repositories
{
    public interface ICauHoiRepository
    {
        Task<IEnumerable<CauHoi>> GetAllAsync();
        Task<CauHoi> GetByIdAsync(int id);
        Task AddAsync(CauHoi cauHoi);
        Task UpdateAsync(CauHoi cauHoi);
        Task DeleteAsync(int id);
    }
}
