using System.Collections.Generic;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("appears_in_level")]
        public List<string> AppearsInLevel { get; set; }
        [JsonProperty("appears_in_game")]
        public List<string> AppearsInGame { get; set; }
    }
}