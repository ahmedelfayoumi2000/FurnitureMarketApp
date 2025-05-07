namespace FurnitureMarketApp.Domain.Entities
{
    public class FurnitureItem
    {
        public int ID { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public decimal price { get; set; }
        public string title { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}