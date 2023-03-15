using System.Collections.Generic;

namespace Tracker.Models
{
    public class MeatOrder
    {
        public int RestaurantId { get; set; }
        public int MeatOrderId { get; set; }
        public int MeatId { get; set; }
        public Meat Meat { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}