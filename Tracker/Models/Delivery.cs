using System.Collections.Generic;

namespace Tracker.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string DeliveryName { get; set; }
        public int MeatOrderId { get; set; }
        public int VegetableOrderId { get; set; }
        public int AlcoholOrderId { get; set; }

        public List<AlcoholOrder> JoinAlcoholEntities { get; }
        public List<MeatOrder> JoinMeatOrderEntities { get; }
        public List<VegetableOrder> JoinVegetableOrderEntities { get; }
    }
}