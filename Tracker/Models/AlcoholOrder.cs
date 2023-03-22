using System.Collections.Generic;

namespace Tracker.Models
{
    public class AlcoholOrder
    {
        public int RestaurantId { get; set; }
        public int AlcoholOrderId { get; set; }
        // public int DeliveryId { get; set; }
        public int AlcoholId { get; set; }
        public string AlcAndRestaurant { get; set; }
        public Alcohol Alcohol { get; set; }
        public Restaurant Restaurant { get; set; }
        public Delivery Delivery { get; set; }
        // public ApplicationUser User { get; set; }
    }
}