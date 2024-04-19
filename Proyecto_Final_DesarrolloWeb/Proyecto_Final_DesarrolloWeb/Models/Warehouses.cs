using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Warehouses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("warehouse_id")]
        public int Warehouse_Id { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("warehouse_name")]
        public string? Warehouse_Name { get; set; }

        [ForeignKey("Locations")]
        [JsonPropertyName("location_id")]
        public int LOCATION_ID { get; set; }
        public required Locations Locations { get; set; }

        public List<Inventories>? Inventories { get; set; } 
    }
}
