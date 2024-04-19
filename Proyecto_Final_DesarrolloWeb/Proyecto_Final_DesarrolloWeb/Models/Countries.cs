using Proyecto_Final_DesarrolloWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Countries
    {
        [Key]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "La llave debe contener exactamente dos letras.")]  
        [JsonPropertyName("country_id")]
        public string? COUNTRY_ID { get; set; }

        [JsonPropertyName("country_name")]
        public required string COUNTRY_NAME { get; set; }

        [ForeignKey("Regions")]
        [JsonPropertyName("region_id")]
        public int REGION_ID { get; set; }
        public required Regions Regions { get; set; }
    }
}
