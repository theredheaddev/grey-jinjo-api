using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class TransformationQuery: BaseQuery
    {
        public List<int> LevelId { get; set; }
        public List<string> LevelName { get; set; }
    }    
}