using Application.Requests;
using Application.Response;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task InsertAsync(InsertEmployeeRequest request);
        Task UpdateAsync(UpdateEmployeeRequest request);
        Task DeleteAsync(int id);
        Task<GetEmployeeResponse> GetByIdAsync(int id);
        Task<IEnumerable<GetEmployeeResponse>> GetAllAsync();
    }
}
