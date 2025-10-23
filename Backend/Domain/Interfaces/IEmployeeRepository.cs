using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task InsertAsync(Employee model);
        Task UpdateAsync(Employee model);
        Task DeleteAsync(int id);
        Task<Employee?> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}
