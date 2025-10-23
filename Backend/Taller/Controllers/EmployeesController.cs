using Application.Interfaces;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Taller.Controllers
{
    [Route("v1/[Controller]")]
    public class EmployeesController(IEmployeeService employeeService) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] InsertEmployeeRequest request)
        {
            await employeeService.InsertAsync(request);
            return Response(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEmployeeRequest request)
        {
            await employeeService.UpdateAsync(request);
            return Response(true);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await employeeService.DeleteAsync(id);
            return Response(true);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Response(await employeeService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Response(await employeeService.GetAllAsync());
        }
    }
}
