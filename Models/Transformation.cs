using Newtonsoft.Json;

namespace Banjo_kazooie_api.Models
{
    public class Transformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("appears_in_level")]
        public string AppearsInLevel { get; set; }
        [JsonProperty("appears_in_game")]
        public string AppearsInGame { get; set; }
        public int Quantity { get; set; }
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }
    }
}