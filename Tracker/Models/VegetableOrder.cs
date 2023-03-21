using System.Collections.Generic;

namespace Tracker.Models
{
    public class VegetableOrder
    {
        public int RestaurantId { get; set; }
        public int VegetableOrderId { get; set; }
        public int VegetableId { get; set; }

        public Vegetable Vegetable { get; set; }

        public string VegAndRestaurant { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}