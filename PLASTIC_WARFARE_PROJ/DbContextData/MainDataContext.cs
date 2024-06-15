using Microsoft.EntityFrameworkCore;
using PLASTIC_WARFARE_PROJ.Models;

namespace PLASTIC_WARFARE_PROJ.DbContextData
{
    public class MainDataContext:DbContext
    {
        public MainDataContext(DbContextOptions<MainDataContext> options) : base(options) 
        {
        }

        public DbSet<Render_STL> Rendered_STLs { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<PlasticType> PlasticTypes { get; set; }

        public DbSet<ModelOrder> ModelOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelOrder>()
                .HasKey(mo => new { mo.RenderId, mo.OrderId });

            modelBuilder.Entity<ModelOrder>()
                .HasOne(mo => mo.Render_STL)
                .WithMany(r => r.ModelOrders)
                .HasForeignKey(mo => mo.RenderId);

            modelBuilder.Entity<ModelOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(o => o.ModelOrders)
                .HasForeignKey(mo => mo.OrderId);

            modelBuilder.Entity<Order>()
        .HasOne(o => o.PlasticType)
        .WithMany(pt => pt.Orders)
        .HasForeignKey(o => o.PlasticTypeId);
        }

    }
}
