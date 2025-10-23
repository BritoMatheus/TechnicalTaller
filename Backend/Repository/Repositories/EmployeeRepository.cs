using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository() : IEmployeeRepository
    {
        public static List<Employee> Employees = new();

        public Task InsertAsync(Employee model)
        {
            model.Id = Employees.Count + 1;

            Employees.Add(model);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Employee model)
        {
            var inMemoryEmployee = Employees.FirstOrDefault(e => e.Id == model.Id);

            if(inMemoryEmployee is not null)
            {
                inMemoryEmployee.FirstName = model.FirstName;
                inMemoryEmployee.LastName = model.LastName;
                inMemoryEmployee.Position = model.Position;
                inMemoryEmployee.Email = model.Email;
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var inMemoryEmployee = Employees.FirstOrDefault(e => e.Id == id);

            if (inMemoryEmployee is not null)
            {
                Employees.Remove(inMemoryEmployee);
            }

            return Task.CompletedTask;
        }

        public Task<Employee?> GetByIdAsync(int id) =>  Task.FromResult(Employees.FirstOrDefault(e => e.Id == id));

        public Task<IEnumerable<Employee>> GetAllAsync() => Task.FromResult(Employees.AsEnumerable());

    }
}
