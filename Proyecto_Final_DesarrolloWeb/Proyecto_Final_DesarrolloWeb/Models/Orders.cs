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
        [JsonPropertyName("order_id")]
        public int ORDER_ID { get; set; }

        [ForeignKey("Customers")]
        [JsonPropertyName("customer_id")]
        public int CUSTOMER_ID { get; set; }
        public required Customers Customers { get; set; }

        [JsonPropertyName("salesman_id")]
        public int? SALESMAN_ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("order_date")]
        public DateTime ORDER_DATE { get; set; }

        [Required]
        [JsonPropertyName("status")]
        public required string STATUS { get; set; }

        public List<OrderItems>? OrderItems { get; set; }
    }
}
