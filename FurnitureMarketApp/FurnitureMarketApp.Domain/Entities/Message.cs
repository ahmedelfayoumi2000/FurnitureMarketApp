using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Domain.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }

        public User User { get; set; }
    }
}
