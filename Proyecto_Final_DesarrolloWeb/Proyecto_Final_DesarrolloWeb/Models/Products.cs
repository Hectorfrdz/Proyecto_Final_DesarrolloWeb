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
        public int product_id { get; set; }

        [JsonPropertyName("product_name")]
        public string? product_name { get; set; }

        [JsonPropertyName("description")]
        public string? description { get; set; } 

        [JsonPropertyName("standard_cost")]
        public decimal standard_cost { get; set; }

        [JsonPropertyName("list_price")]
        public decimal list_price { get; set; }

        [ForeignKey("Product_Categories")]
        [JsonPropertyName("category_id")]
        public int category_id { get; set; }
        public required Product_Categories Product_Categories { get; set; }

        public List<OrderItems>? OrderItems { get; set; }
    }
}
