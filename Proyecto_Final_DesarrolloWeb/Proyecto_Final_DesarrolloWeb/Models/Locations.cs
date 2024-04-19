using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Locations
    {
        [Key]
        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [StringLength(20)]
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        [StringLength(50)]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [StringLength(50)]
        [JsonPropertyName("state")]
        public string? State { get; set; }

        [ForeignKey("Country")]
        [JsonPropertyName("country_id")]
        public string CountryId { get; set; }
        public Countries? Country { get; set; }
    }
}
