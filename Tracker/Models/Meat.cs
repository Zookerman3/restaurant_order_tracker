using System.Collections.Generic;

namespace Tracker.Models
{
    public class Meat
    {
        public int MeatId { get; set; }
        
        public string MeatType { get; set; }
        public string MeatAmount { get; set; }
        public ApplicationUser User { get; set; } 
        public List<MeatOrder> JoinMeatOrderEntities { get;}
    }
}