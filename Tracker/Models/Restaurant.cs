using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "The item's description can't be empty!")]
        public string Name { get; set; }
        public string Location { get; set; }
        public ApplicationUser User { get; set; } 
        public List<AlcoholOrder> JoinAlcoholEntities { get;}
        public List<MeatOrder> JoinMeatOrderEntities { get;}
        public List<VegetableOrder> JoinVegetableOrderEntities { get;}
    }
}