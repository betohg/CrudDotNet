﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoFinalCruds.Models
{
    public class Countries
    {
        [Key]
        [JsonPropertyName("country_id")]
        public char? COUNTRY_ID { get; set; }
        [JsonPropertyName("country_name")]

        public string? COUNTRY_NAME { get; set; }
        [JsonPropertyName("region_id")]

        public string? REGION_ID { get; set; }
   
    }
}
