using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbContextEntity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<OrderStatusMaster> OrderStatusMasters { get; set; }
        public DbSet<DeliveryStatusMaster> DeliveryStatusMasters { get; set; }
        public DbSet<PaymentStatusMaster> PaymentStatusMasters { get; set; }
        public DbSet<PaymentTypeMaster> PaymentTypeMasters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryPartnerProfile> DeliveryPartnerProfiles { get; set; }
        public DbSet<RestaurantOwnerProfile> RestaurantOwnerProfiles { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantAddress> RestaurantAddresses { get; set; }
        public DbSet<RestaurantClosure> RestaurantClosures { get; set; }
        public DbSet<CuisineMaster> Cuisines { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OrderOffer> OrderOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite keys for many-to-many bridging tables
            modelBuilder.Entity<RestaurantCuisine>()
                .HasKey(rc => new { rc.RestaurantId, rc.CuisineMasterId });

            // Configure relationships to prevent multiple cascade paths
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade deletion

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade deletion

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Order)
                .WithOne(o => o.Delivery)
                .HasForeignKey<Delivery>(d => d.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.DeliveryPartnerProfile)
                .WithMany(u => u.Deliveries)
                .HasForeignKey(d => d.DeliveryPartnerProfileId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Order>()
                .HasOne(o => o.UserAddress)
                .WithMany()
                .HasForeignKey(o => o.UserAddressId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Master table seeding

            // 1. RoleMaster
            modelBuilder.Entity<RoleMaster>().HasData(
                new RoleMaster { RoleMasterId = 1, RoleName = "SuperAdmin", Description = "Super Admin", IsActive = true },
                new RoleMaster { RoleMasterId = 2, RoleName = "Admin", Description = "System administrator", IsActive = true },
                new RoleMaster { RoleMasterId = 3, RoleName = "Customer", Description = "Regular user placing orders", IsActive = true },
                new RoleMaster { RoleMasterId = 4, RoleName = "DeliveryPartner", Description = "Delivery personnel", IsActive = true },
                new RoleMaster { RoleMasterId = 5, RoleName = "RestaurantOwner", Description = "Restaurant owner", IsActive = true }
            );

            // 2. OrderStatusMaster
            modelBuilder.Entity<OrderStatusMaster>().HasData(
                new OrderStatusMaster { OrderStatusMasterId = 1, StatusName = "Placed", Description = "Order received", IsActive = true },
                new OrderStatusMaster { OrderStatusMasterId = 2, StatusName = "Confirmed", Description = "Restaurant confirmed the order", IsActive = true },
                new OrderStatusMaster { OrderStatusMasterId = 3, StatusName = "Preparing", Description = "Food is being prepared", IsActive = true },
                new OrderStatusMaster { OrderStatusMasterId = 4, StatusName = "OutForDelivery", Description = "Rider is out for delivery", IsActive = true },
                new OrderStatusMaster { OrderStatusMasterId = 5, StatusName = "Delivered", Description = "Order delivered", IsActive = true },
                new OrderStatusMaster { OrderStatusMasterId = 6, StatusName = "Cancelled", Description = "Order cancelled", IsActive = true }
            );

            // 3. DeliveryStatusMaster
            modelBuilder.Entity<DeliveryStatusMaster>().HasData(
                new DeliveryStatusMaster { DeliveryStatusMasterId = 1, StatusName = "Assigned", Description = "Delivery assigned to partner", IsActive = true },
                new DeliveryStatusMaster { DeliveryStatusMasterId = 2, StatusName = "PickedUp", Description = "Delivery partner has picked up the order", IsActive = true },
                new DeliveryStatusMaster { DeliveryStatusMasterId = 3, StatusName = "EnRoute", Description = "Order is on the way", IsActive = true },
                new DeliveryStatusMaster { DeliveryStatusMasterId = 4, StatusName = "Delivered", Description = "Order delivered to the customer", IsActive = true }
            );

            // 4. PaymentStatusMaster
            modelBuilder.Entity<PaymentStatusMaster>().HasData(
                new PaymentStatusMaster { PaymentStatusMasterId = 1, StatusName = "Pending", Description = "Awaiting payment confirmation", IsActive = true },
                new PaymentStatusMaster { PaymentStatusMasterId = 2, StatusName = "Completed", Description = "Payment received", IsActive = true },
                new PaymentStatusMaster { PaymentStatusMasterId = 3, StatusName = "Failed", Description = "Payment failed", IsActive = true }
            );

            // 5. PaymentTypeMaster
            modelBuilder.Entity<PaymentTypeMaster>().HasData(
                new PaymentTypeMaster { PaymentTypeMasterId = 1, TypeName = "CreditCard", Description = "Pay using credit card", IsActive = true },
                new PaymentTypeMaster { PaymentTypeMasterId = 2, TypeName = "UPI", Description = "Unified Payments Interface", IsActive = true },
                new PaymentTypeMaster { PaymentTypeMasterId = 3, TypeName = "CashOnDelivery", Description = "Pay with cash upon delivery", IsActive = true }
            );

            // 6. Seed Cuisine data
            modelBuilder.Entity<CuisineMaster>().HasData(
                new CuisineMaster { CuisineMasterId = 1, CuisineName = "Indian", IsActive = true },
                new CuisineMaster { CuisineMasterId = 2, CuisineName = "Chinese", IsActive = true },
                new CuisineMaster { CuisineMasterId = 3, CuisineName = "Italian", IsActive = true },
                new CuisineMaster { CuisineMasterId = 4, CuisineName = "Mexican", IsActive = true },
                new CuisineMaster { CuisineMasterId = 5, CuisineName = "American", IsActive = true },
                new CuisineMaster { CuisineMasterId = 6, CuisineName = "Thai", IsActive = true }
            );
        }
    }

}
