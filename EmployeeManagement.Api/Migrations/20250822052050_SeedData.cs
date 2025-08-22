using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CurrentProject", "Location", "Manager", "Name", "Skills" },
                values: new object[,]
                {
                    { 1, "Project A", "New York", "Jane Smith", "John Doe", "C#, ASP.NET Core, SQL" },
                    { 2, "Project B", "San Francisco", "Bob Brown", "Alice Johnson", "Java, Spring Boot, MySQL" },
                    { 3, "Project C", "Chicago", "Sara Davis", "Michael Williams", "Python, Django, PostgreSQL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
