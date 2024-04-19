using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Employees
    {
        [Key]
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [StringLength(50)]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("hire_date")]
        public DateTime HireDate { get; set; }

        [JsonPropertyName("manager_id")]
        public int? ManagerId { get; set; }
        public Employees? Manager { get; set; } 

        [Required]
        [StringLength(255)]
        [JsonPropertyName("job_title")]
        public string? JobTitle { get; set; }

        //public List<Departments>? Departments { get; set; } 
    }
}
