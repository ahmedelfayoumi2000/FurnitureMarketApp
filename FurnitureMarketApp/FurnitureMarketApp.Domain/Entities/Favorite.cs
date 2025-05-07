using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Domain.Entities
{
    public class Favorite
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public int ID_item { get; set; }
        public string name { get; set; }

        public User User { get; set; }
        public FurnitureItem FurnitureItem { get; set; }
    }
}
