using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.DTOs
{
    public class FavoriteDto
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public int ID_item { get; set; }
        public string name { get; set; }
    }
}
