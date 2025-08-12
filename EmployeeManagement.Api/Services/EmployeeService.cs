using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;

namespace EmployeeManagement.Api.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repo.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _repo.Add(employee);
        }
    }
}