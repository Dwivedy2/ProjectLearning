using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;
using EmployeeManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _service.CreateEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _service.GetEmployeeById(id);
            if (existingEmployee == null) return NotFound();

            _service.UpdateEmployee(employee);
            return Ok(employee);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null) return NotFound();

            _service.DeleteEmployee(id);
            return NoContent();
        }
    }
}