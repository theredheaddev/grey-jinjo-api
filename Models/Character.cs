using System.Collections.Generic;

namespace Banjo_kazooie_api.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Games { get; set; }
    }
}