using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class BaseQuery 
    {
        public List<int> Id { get; set; }
        public List<string> Name { get; set; }
        public List<int> GameId { get; set; }
        public List<int> LevelId { get; set; }
    }
}