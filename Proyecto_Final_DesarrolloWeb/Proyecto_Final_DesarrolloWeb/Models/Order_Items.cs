using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class OrderItems
    {
        [Key]
        [JsonPropertyName("orderitem_id")]
        public string? ORDERITEM_ID { get; set; }

        [ForeignKey("Order")]
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
        public Orders? Order { get; set; }

        [JsonPropertyName("item_id")]
        public int ItemId { get; set; } 

        [ForeignKey("Product")]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }
        public Products? Product { get; set; } 

        [Required]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        [JsonPropertyName("unit_price")]
        public decimal UnitPrice { get; set; }
    }
}
