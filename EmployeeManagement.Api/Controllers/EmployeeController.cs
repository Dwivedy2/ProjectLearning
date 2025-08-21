using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;
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
        public ActionResult<List<EmployeeDto>> GetAll()
        {
            return Ok(_service.GetAllEmployees().Select(e => _mapper.Map<EmployeeDto>(e)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public ActionResult<EmployeeDto> Create(EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest("Employee data is null");
            var employee = _mapper.Map<Employee>(employeeDto);
            _service.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employeeDto);
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> Update(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null) return BadRequest("Employee data is null");
            if (id != employeeDto.Id) return BadRequest("Employee ID mismatch");

            var existingEmployee = _service.GetEmployeeById(id);

            if (existingEmployee == null) return NotFound();

            _mapper.Map(employeeDto, existingEmployee);
            _service.UpdateEmployee(existingEmployee);
            return Ok(employeeDto);
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