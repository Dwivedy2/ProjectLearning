using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;

namespace EmployeeManagement.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new();
        }
        public void Add(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}