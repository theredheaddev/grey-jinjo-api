using System;
using System.Collections.Generic;

namespace Banjo_kazooie_api.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Platform { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Levels { get; set; }
        public List<string> Collectables { get; set; }
    }
}