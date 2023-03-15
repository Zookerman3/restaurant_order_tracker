using System.Collections.Generic;

namespace Tracker.Models
{
    public class Vegetable
    {
        public int VegetableId { get; set; }
        
        public string VegetableType { get; set; }
        public string VegetableAmount { get; set; }
        public List<VegetableOrder> JoinVegetableOrderEntities { get; }
    }
}