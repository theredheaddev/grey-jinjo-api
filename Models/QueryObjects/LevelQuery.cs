using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class LevelQuery: BaseQuery
    {
        public List<string> LevelType { get; set; }
        public List<int> LevelNumber { get; set; }
        public List<int> EnemyId { get; set; }
        public List<int> AreaId { get; set; }
        public List<int> AbilityId { get; set; }
        public List<int> CharacterId { get; set; }
        public List<int> CollectableId { get; set; }
        public List<int> TransformationId { get; set; }
    }    
}