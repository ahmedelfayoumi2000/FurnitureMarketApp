using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.DTOs
{
    public class FurnitureItemDto
    {
        public int ID { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public decimal price { get; set; }
        public string title { get; set; }
    }
}
