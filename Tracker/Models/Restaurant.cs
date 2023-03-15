using System.Collections.Generic;

namespace Tracker.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<AlcoholOrder> JoinAlcoholEntities { get;}
        public List<MeatOrder> JoinMeatOrderEntities { get;}
        public List<VegetableOrder> JoinVegetableOrderEntities { get;}
    }
}