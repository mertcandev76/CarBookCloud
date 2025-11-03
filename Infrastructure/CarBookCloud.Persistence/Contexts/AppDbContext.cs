using CarBookCloud.Domain.Entities;
using CarBookCloud.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // -----------------
        // DbSet’ler
        // -----------------
        public DbSet<About> Abouts => Set<About>();
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarDescription> CarDescriptions => Set<CarDescription>();
        public DbSet<CarFeature> CarFeatures => Set<CarFeature>();
        public DbSet<CarPricing> CarPricings => Set<CarPricing>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Feature> Features => Set<Feature>();
        public DbSet<FooterAddress> FooterAddresses => Set<FooterAddress>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Pricing> Pricings => Set<Pricing>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<SocialMedia> SocialMedias => Set<SocialMedia>();
        public DbSet<Testimonial> Testimonials => Set<Testimonial>();

        // -----------------
        // Model Configuration
        // -----------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------
            // Domain Events Ignore
            // -----------------
            modelBuilder.Ignore<IDomainEvent>();
            modelBuilder.Ignore<List<IDomainEvent>>();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IHasDomainEvents).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Ignore(nameof(IHasDomainEvents.DomainEvents));
                }
            }

            // -----------------
            // Relationships
            // -----------------
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Cars)
                .WithOne(c => c.Brand)
                .HasForeignKey(c => c.BrandID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarFeatures)
                .WithOne(cf => cf.Car)
                .HasForeignKey(cf => cf.CarID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarDescriptions)
                .WithOne(cd => cd.Car)
                .HasForeignKey(cd => cd.CarID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarPricings)
                .WithOne(cp => cp.Car)
                .HasForeignKey(cp => cp.CarID)
                .OnDelete(DeleteBehavior.Cascade);

            // -----------------
            // Value Object Mapping (Price)
            // -----------------
            modelBuilder.Entity<CarPricing>(eb =>
            {
                eb.OwnsOne(cp => cp.Amount, a =>
                {
                    a.Property(p => p.Amount)
                     .HasColumnName("AmountValue")
                     .IsRequired();
                });
            });

            // -----------------
            // Apply Configurations (optional but recommended)
            // -----------------
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
