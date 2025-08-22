using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Api.Models
{
    [NotMapped]
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}