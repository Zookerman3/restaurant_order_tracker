using System.Collections.Generic;

namespace Tracker.Models
{
    public class Delivery
    {
        public int RestaurantOrderId { get; set; }
        public int MeatOrderId { get; set; }
        public int VegetableOrderId { get; set; }
        public int AlcoholOrderId { get; set; }
    }
}