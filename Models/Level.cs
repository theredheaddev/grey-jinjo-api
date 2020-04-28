using System.Collections.Generic;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("appears_in_game")]
        public List<string> AppearsInGame { get; set; }
        public string Type { get; set; }
        [JsonProperty("level_number")]
        public int? LevelNumber { get; set; }
        [JsonProperty("jiggy_locations")]
        public List<string> JiggyLocations { get; set; }
        [JsonProperty("jinjo_locations")]
        public List<string> JinjoLocations { get; set; }
        [JsonProperty("empty_honeycomb_locations")]
        public List<string> EmptyHoneycombLocations { get; set; }
        [JsonProperty("life_locations")]
        public List<string> LifeLocations { get; set; }
        public List<string> Collectables { get; set; }
        public List<string> Enemies { get; set; }
        public List<string> Areas { get; set; }
        [JsonProperty("abilities_learned")]
        public List<string> AbilitiesLearned { get; set; }
        [JsonProperty("mumbo_tokens")]
        public List<string> MumboTokens { get; set; }
        public List<string> Characters { get; set; }
        [JsonProperty("mini_games")]
        public List<string> MiniGames { get; set; }
        [JsonProperty("witch_switches")]
        public List<string> WitchSwitches { get; set; }
        public List<string> Transformations { get; set; }
    }
}