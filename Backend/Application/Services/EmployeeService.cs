using Application.Interfaces;
using Application.Requests;
using Application.Response;
using Application.Validators;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository): IEmployeeService
    {
        public async Task InsertAsync(InsertEmployeeRequest request)
        {
            new InsertEmployeeValidator().ValidateAndThrow(request);

            var model = (Employee)request;

            await employeeRepository.InsertAsync(model);
        }

        public async Task UpdateAsync(UpdateEmployeeRequest request)
        {
            new UpdateEmployeeValidator().ValidateAndThrow(request);

            var model = (Employee)request;

            await employeeRepository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            new DeleteEmployeeValidator().ValidateAndThrow(id);

            await employeeRepository.DeleteAsync(id);
        }

        public async Task<GetEmployeeResponse> GetByIdAsync(int id)
        {
            var model = await employeeRepository.GetByIdAsync(id);
            return (GetEmployeeResponse)model;
        }

        public async Task<IEnumerable<GetEmployeeResponse>> GetAllAsync()
        {
            var models = await employeeRepository.GetAllAsync();
            var responses = models.Select(m => (GetEmployeeResponse)m);
            return responses;
        }
    }
}
