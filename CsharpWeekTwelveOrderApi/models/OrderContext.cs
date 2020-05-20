using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models
{
    public class OrderContext : DbContext{
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options){
            this.Database.EnsureCreated(); //自动建库建表
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(t => new { t.OrderId, t.ProductId });
            base.OnModelCreating(modelBuilder);
        }
    }
}