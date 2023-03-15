using Microsoft.EntityFrameworkCore;

namespace Tracker.Models
{
    public class TrackerContext : DbContext
    {
        public DbSet<Meat> Meat { get; set; }
        public DbSet<Vegetable> Vegetable { get; set; }
        public DbSet<Alcohol> Alcohol { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<MeatOrder> RestaurantMeatOrder { get; set; }
        public DbSet<VegetableOrder> RestaurantVegetableOrder { get; set; }
        public DbSet<AlcoholOrder> RestaurantAlcoholOrder { get; set; }
        public DbSet<RestaurantOrder> RestaurantOrder { get; set; }

        public TrackerContext(DbContextOptions options) : base(options) { }
    }
}