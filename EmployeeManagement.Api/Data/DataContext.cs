using EmployeeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Skills = "C#, ASP.NET Core, SQL",
                    CurrentProject = "Project A",
                    Manager = "Jane Smith",
                    Location = "New York"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Alice Johnson",
                    Skills = "Java, Spring Boot, MySQL",
                    CurrentProject = "Project B",
                    Manager = "Bob Brown",
                    Location = "San Francisco"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Michael Williams",
                    Skills = "Python, Django, PostgreSQL",
                    CurrentProject = "Project C",
                    Manager = "Sara Davis",
                    Location = "Chicago"
                }
            );
        }
    }
}