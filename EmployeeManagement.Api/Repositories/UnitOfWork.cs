using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Repositories.Interfaces;

namespace EmployeeManagement.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IEmployeeRepository Employees { get; }

        public UnitOfWork(DataContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            Employees = employeeRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}