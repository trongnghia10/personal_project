using Microsoft.EntityFrameworkCore;
using project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.EF
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext()
        {
        }

        public ShopDbContext(DbContextOptions options) : base(options) { }
        //DbSet
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Roles");
                e.HasKey(x => x.id);
                e.Property(x => x.roleName).IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(x => x.id);
                e.Property(x => x.id).UseIdentityColumn();
                e.Property(x=>x.fullname).IsRequired().HasMaxLength(200);
                e.Property(x=>x.email).IsRequired().HasMaxLength(200);
                e.Property(x=>x.phoneNumber).IsRequired().HasMaxLength(200);
                e.Property(x=>x.address).IsRequired().HasMaxLength(200);
                e.Property(x=>x.username).IsRequired().HasMaxLength(200);
                e.Property(x=>x.password).IsRequired().HasMaxLength(200);
                e.HasOne(x => x.role).WithMany(x => x.users).HasForeignKey(x => x.roleId);
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.HasKey(x => x.id);
                e.Property(x => x.id).UseIdentityColumn();
                e.Property(x => x.name).IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(x => x.id);
                e.Property(x => x.id).UseIdentityColumn();
                e.Property(x => x.name).IsRequired().HasMaxLength(200);
                e.Property(x => x.price).IsRequired();
                e.Property(x => x.quantity).IsRequired();
                e.Property(x => x.description).IsRequired();
                e.Property(x => x.imagePath).IsRequired();
                e.HasOne(x => x.category).WithMany(x => x.products).HasForeignKey(x => x.categoryId);
            });
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(x => x.id);
                e.Property(x => x.id).UseIdentityColumn();
                e.Property(x => x.fullname).IsRequired().HasMaxLength(200);
                e.Property(x => x.email).IsRequired();
                e.Property(x => x.phoneNumber).IsRequired();
                e.Property(x => x.address).IsRequired().HasMaxLength(200);
                e.Property(x => x.orderDate).IsRequired();
                e.Property(x => x.status).IsRequired();
                e.HasOne(x => x.user).WithMany(x => x.orders).HasForeignKey(x => x.userId);
            });
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(x => new {x.productId, x.orderId});
                e.Property(x => x.quantity).IsRequired();
                e.Property(x => x.totalPrice).IsRequired();

                e.HasOne(x => x.order).WithMany(x => x.orderDetails).HasForeignKey(x => x.orderId);
                e.HasOne(x => x.product).WithMany(x => x.orderDetails).HasForeignKey(x => x.productId);
            });

        }
    }
}
