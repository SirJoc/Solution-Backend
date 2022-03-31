using Crud.API.Domain.Models;
using Crud.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Cloth
            builder.Entity<Cloth>().ToTable("Cloths");
            builder.Entity<Cloth>().HasKey(p => p.Id);
            builder.Entity<Cloth>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cloth>().Property(p => p.Brand).IsRequired();
            builder.Entity<Cloth>().Property(p => p.Color).IsRequired();
            //Relationships
            builder.Entity<Cloth>()
                .HasMany(p => p.OrdersDetails)
                .WithOne(p => p.Cloth)
                .HasForeignKey(p => p.ClothId);
            
            //Order
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(p => p.Id);
            builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Relationships
            builder.Entity<Order>()
                .HasMany(p => p.OrderDetails)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);
            
            //Order details
            builder.Entity<OrderDetail>().ToTable("OrderDetails");
            builder.Entity<OrderDetail>().HasKey(p => p.Id);
            builder.Entity<OrderDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //Relationships
            builder.Entity<OrderDetail>()
                .HasOne(t => t.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(e => e.OrderId);
            builder.Entity<OrderDetail>()
                .HasOne(p => p.Cloth)
                .WithMany(p => p.OrdersDetails)
                .HasForeignKey(p => p.ClothId);
            
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}