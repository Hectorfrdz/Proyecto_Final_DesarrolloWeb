using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Inventories
    {
        [Key]
        [JsonPropertyName("inventory_id")]
        public int InventoryId { get; set; }

        [Required]
        [ForeignKey("Product")]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }
        public Products? Product { get; set; } 

        [Required]
        [ForeignKey("Warehouse")]
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }

        [Required]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
