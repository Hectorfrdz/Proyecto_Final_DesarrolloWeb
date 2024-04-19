using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; } 

        [Required]
        [ForeignKey("Salesman")]
        [JsonPropertyName("salesman_id")]
        public int? SalesmanId { get; set; } 
        public Employees? Salesman { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("order_date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("status")]
        public required string Status { get; set; }

        public List<OrderItems>? OrderItems { get; set; }
    }
}
