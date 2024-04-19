﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Proyecto_Final_DesarrolloWeb.Models
{
    public class Regions
    {
        [Key]
        [JsonPropertyName("region_id")]
        public int REGION_ID { get; set; }
        [JsonPropertyName("region_name")]
        public string? REGION_NAME { get; set; }
    }
}
