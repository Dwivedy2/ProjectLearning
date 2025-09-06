using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;
using EmployeeManagement.Api.Services.Interfaces;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _employeeRepository = _unitOfWork.GetRepository<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Fetching all employees");
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching employee with ID: {id}");
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            _logger.LogInformation("Creating a new employee");
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _logger.LogInformation($"Updating employee with ID: {employee.Id}");
            _employeeRepository.Update(employee);  
            await _unitOfWork.SaveChangesAsync(); 
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            _logger.LogInformation($"Deleting employee with ID: {id}");
            var empToDel = await _employeeRepository.GetByIdAsync(id);
            if (empToDel != null)
            {
                _employeeRepository.Delete(empToDel);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                _logger.LogWarning($"Employee with ID: {id} not found");
            }
        }
    }
}