using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string user_phone { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
