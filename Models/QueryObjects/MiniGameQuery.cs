using System.Collections.Generic;

namespace Banjo_kazooie_api.Models.QueryObjects
{
    public class MiniGameQuery : BaseQuery
    {
        public List<string> Rules { get; set; }
        public List<string> Description { get; set; }
        public List<string> AreaId { get; set; }
    }
}