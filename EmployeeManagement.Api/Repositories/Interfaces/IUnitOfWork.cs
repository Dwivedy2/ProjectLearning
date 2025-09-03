namespace EmployeeManagement.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       IEmployeeRepository Employees { get; }
       void SaveChanges(); 
    }
}