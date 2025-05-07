using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.DTOs
{
    public class MessageDto
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }
    }
}
