using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Products
    {
        [Key]
        [JsonPropertyName("product_id")]
        public int PRODUCT_ID { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("product_name")]
        public string? PRODUCT_NAME { get; set; }

        [StringLength(2000)]
        [JsonPropertyName("description")]
        public string? DESCRIPTION { get; set; } 

        [Column(TypeName = "decimal(9, 2)")]
        [JsonPropertyName("standard_cost")]
        public decimal STANDARD_COST { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        [JsonPropertyName("list_price")]
        public decimal LIST_PRICE { get; set; }

        [ForeignKey("product_categories")]
        [JsonPropertyName("category_id")]
        public int CATEGORY_ID { get; set; }
        public required Product_Categories product_categories { get; set; }


        public List<OrderItems>? OrderItems { get; set; }
    }
}
