using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;
using EmployeeManagement.Api.Services.Interfaces;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepo;

        public EmployeeService(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _empRepo.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _empRepo.GetById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _empRepo.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _empRepo.Update(employee);   
        }

        public void DeleteEmployee(int id)
        {
            _empRepo.Delete(id);
        }
    }
}