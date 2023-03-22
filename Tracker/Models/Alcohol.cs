using System.Collections.Generic;

namespace Tracker.Models
{
    public class Alcohol
    {
        public int AlcoholId { get; set; }
        public string AlcoholType { get; set; }
        public string AlcoholAmount { get; set; }
        public List<AlcoholOrder> JoinAlcoholEntities { get;}
        public ApplicationUser User { get; set; }
    }
}