using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Skills { get; set; } = string.Empty;
        public string CurrentProject { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
    }
}