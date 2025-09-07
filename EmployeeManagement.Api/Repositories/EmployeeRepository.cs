using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories.Interfaces;

namespace EmployeeManagement.Api.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {

        public EmployeeRepository(DataContext context) : base(context)
        {
        }
    }
}