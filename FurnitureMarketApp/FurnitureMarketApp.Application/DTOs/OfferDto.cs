using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.DTOs
{
    public class OfferDto
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public int ID_item { get; set; }
        public decimal offerPrice { get; set; }
        public string status { get; set; }
    }
}
