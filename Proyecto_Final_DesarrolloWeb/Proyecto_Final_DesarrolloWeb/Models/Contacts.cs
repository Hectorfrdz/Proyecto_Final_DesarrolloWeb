using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("contact_id")] 
        public int ContactId { get; set; }

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

        [StringLength(20)]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("customer_id")]
        public int? CustomerId { get; set; }
    }
}
