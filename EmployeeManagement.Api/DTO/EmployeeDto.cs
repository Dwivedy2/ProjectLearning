namespace EmployeeManagement.Api.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string CurrentProject { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}