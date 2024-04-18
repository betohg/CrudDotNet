using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoFinalCruds.Models
{
    public class Iventories
    {

        [Key]
        [JsonPropertyName("PRODUCT_ID")]
        public int? PRODUCT_ID { get; set; }
        [JsonPropertyName("[warehouse_id]")]
        public int? WAREHOUSE_ID { get; set; }
        [JsonPropertyName("quantity")]
        public int? QUANTITY { get; set; }
     

    }
}
