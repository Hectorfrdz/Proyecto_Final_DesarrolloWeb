using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Contacts
    {
        [Key]
        [JsonPropertyName("contact_id")] 
        public int CONTACT_ID { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("first_name")]
        public string? FIRST_NAME { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("last_name")]
        public string? LAST_NAME { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("email")]
        public string? EMAIL { get; set; }

        [StringLength(20)]
        [JsonPropertyName("phone")]
        public string? PHONE { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        public int CUSTOMER_ID { get; set; }
        public required Customers Customers{ get; set; }
    }
}
