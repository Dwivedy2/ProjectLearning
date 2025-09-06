using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Api.DTO;
using AutoMapper;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllAsync()
        {
            var employees = await _service.GetAllEmployeesAsync();
            employees.Select(e => _mapper.Map<EmployeeDto>(e)).ToList();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateAsync(EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest("Employee data is null");
            var employee = _mapper.Map<Employee>(employeeDto);
            await _service.CreateEmployeeAsync(employee);
            return CreatedAtAction(
                "GetById",
                new { id = employee.Id },
                _mapper.Map<EmployeeDto>(employee)
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateAsync(int id, [FromBody]EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest("Employee data is null");

            var existingEmployee = await _service.GetEmployeeByIdAsync(id);

            if (existingEmployee == null) return NotFound();

            _mapper.Map(employeeDto, existingEmployee);
            existingEmployee.Id = id;
            await _service.UpdateEmployeeAsync(existingEmployee);
            return Ok(employeeDto);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();

            await _service.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}