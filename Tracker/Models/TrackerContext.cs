using Microsoft.EntityFrameworkCore;

namespace Tracker.Models
{
    public class TrackerContext : DbContext
    {
        public DbSet<Meat> Meats { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MeatOrder> RestaurantMeatOrder { get; set; }
        public DbSet<VegetableOrder> RestaurantVegetableOrder { get; set; }
        public DbSet<AlcoholOrder> RestaurantAlcoholOrder { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        public TrackerContext(DbContextOptions options) : base(options) { }
    }
}