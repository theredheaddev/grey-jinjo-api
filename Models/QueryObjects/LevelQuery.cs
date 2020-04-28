using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class LevelQuery: BaseQuery
    {
        public List<string> LevelType { get; set; }
        public List<int> LevelNumber { get; set; }
        public List<int> EnemyId { get; set; }
        public List<string> EnemyName { get; set; }
        public List<int> AreaId { get; set; }
        public List<string> AreaName { get; set; }
        public List<int> AbilityId { get; set; }
        public List<string> AbilitName { get; set; }
        public List<int> CharacterId { get; set; }
        public List<string> CharacterName { get; set; }
        public List<int> TransformationId { get; set; }
        public List<string> TransformationName { get; set; }
    }    
}