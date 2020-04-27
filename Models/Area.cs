using System.Collections.Generic;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonProperty("appears_in")]
        public List<string> AppearsIn { get; set; }
    }
}