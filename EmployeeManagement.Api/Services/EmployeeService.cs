using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;
using EmployeeManagement.Api.Services.Interfaces;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(ILogger<EmployeeService> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            _logger.LogInformation("Fetching all employees");
            return _unitOfWork.Employees.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            _logger.LogInformation($"Fetching employee with ID: {id}");
            return _unitOfWork.Employees.GetById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _logger.LogInformation("Creating a new employee");
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _logger.LogInformation($"Updating employee with ID: {employee.Id}");
            _unitOfWork.Employees.Update(employee);  
            _unitOfWork.SaveChanges(); 
        }

        public void DeleteEmployee(int id)
        {
            _logger.LogInformation($"Deleting employee with ID: {id}");
            var empToDel = _unitOfWork.Employees.GetById(id);
            if (empToDel != null)
            {
                _unitOfWork.Employees.Delete(empToDel);
                _unitOfWork.SaveChanges();
            }
            else
            {
                _logger.LogWarning($"Employee with ID: {id} not found");
            }
        }
    }
}