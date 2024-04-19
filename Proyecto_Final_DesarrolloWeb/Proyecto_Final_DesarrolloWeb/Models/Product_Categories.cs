using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Product_Categories
    {
        [Key]
        [JsonPropertyName("category_id")]
        public int CATEGORY_ID { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("category_name")]
        public required string CATEGORY_NAME { get; set; }

        public List<Products>? Products { get; set; } 
    }
}
