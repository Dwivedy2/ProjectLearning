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

        public void Delete(int id)
        {
            _employees.RemoveAll(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {
            var existingEmployee = GetById(employee.Id);
            if (existingEmployee == null) return;
            
            existingEmployee.Name = employee.Name;
            existingEmployee.Location = employee.Location;
            existingEmployee.Manager = employee.Manager;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.CurrentProject = employee.CurrentProject;
        }
    }
}