using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tracker.Models
{
    public class TrackerContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Meat> Meats { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MeatOrder> MeatOrders { get; set; }
        public DbSet<VegetableOrder> VegetableOrders { get; set; }
        public DbSet<AlcoholOrder> AlcoholOrders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public TrackerContext(DbContextOptions options) : base(options) { }
    }
}