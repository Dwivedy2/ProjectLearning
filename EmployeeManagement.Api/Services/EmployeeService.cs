using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;
using EmployeeManagement.Api.Services.Interfaces;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository empRepo,
        ILogger<EmployeeService> logger)
        {
            _empRepo = empRepo;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            _logger.LogInformation("Fetching all employees");
            return _empRepo.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            _logger.LogInformation($"Fetching employee with ID: {id}");
            return _empRepo.GetById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _logger.LogInformation("Creating a new employee");
            _empRepo.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _logger.LogInformation($"Updating employee with ID: {employee.Id}");
            _empRepo.Update(employee);   
        }

        public void DeleteEmployee(int id)
        {
            _logger.LogInformation($"Deleting employee with ID: {id}");
            _empRepo.Delete(id);
        }
    }
}