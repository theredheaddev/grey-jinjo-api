using System.Collections.Generic;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Models
{
    public class Collectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("game_quantity")]
        public List<GameQuantity> GameQuantity { get; set; }
    }

    public class GameQuantity
    {
        public string Game { get; set; }
        public int? Quantity { get; set; }
    }
}