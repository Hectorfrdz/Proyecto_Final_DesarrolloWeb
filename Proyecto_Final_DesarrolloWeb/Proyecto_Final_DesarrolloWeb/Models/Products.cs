using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }

        [StringLength(2000)]
        [JsonPropertyName("description")]
        public string? Description { get; set; } 

        [Column(TypeName = "decimal(9, 2)")]
        [JsonPropertyName("standard_cost")]
        public decimal StandardCost { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        [JsonPropertyName("list_price")]
        public decimal ListPrice { get; set; }

        [Required]
        [ForeignKey("Category")]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        public Product_Categories? Category { get; set; }

        public List<OrderItems>? OrderItems { get; set; }
    }
}
