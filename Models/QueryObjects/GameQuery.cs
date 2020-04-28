using System;
using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class GameQuery: BaseQuery
    {
        public DateTime Released { get; set; }
        public string Platform { get; set; }
        public List<int> CharacterId { get; set; }
        public List<string> CharacterName { get; set; }
        public List<int> LevelId { get; set; }
        public List<string> LevelName { get; set; }
        public List<int> CollectableId { get; set; }
        public List<string> CollectableName { get; set; }

    }    
}