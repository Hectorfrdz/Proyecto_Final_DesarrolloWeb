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
        public int LOCATION_ID { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("address")]
        public string? ADDRESS { get; set; }

        [StringLength(20)]
        [JsonPropertyName("postal_code")]
        public string? POSTAL_CODE { get; set; }

        [StringLength(50)]
        [JsonPropertyName("city")]
        public string? CITY { get; set; }

        [StringLength(50)]
        [JsonPropertyName("state")]
        public string? STATE { get; set; }

        [ForeignKey("Country")]
        [JsonPropertyName("country_id")]
        public required string COUNTRY_ID { get; set; }
        public required Countries Country { get; set; }
    }
}
