using Nhom6_DoAnMonHoc.Models;

namespace Nhom6_DoAnMonHoc.Repositories
{
    public interface IDeThiRepository
    {
        Task<IEnumerable<DeThi>> GetAllAsync();
        Task<DeThi> GetByIdAsync(int id);
        Task AddAsync(DeThi deThi);
        Task UpdateAsync(DeThi deThi);
        Task DeleteAsync(int id);
    }
}
