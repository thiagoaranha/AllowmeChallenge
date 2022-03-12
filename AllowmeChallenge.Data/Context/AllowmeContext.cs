using AllowmeChallenge.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AllowmeChallenge.Data.Context
{
    public class AllowmeContext : DbContext
    {
        public AllowmeContext(DbContextOptions<AllowmeContext> options) : base(options)
        {
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<ServiceRequests> ServiceRequests { get; set; }
        public DbSet<Billings> Billings { get; set; }
        public DbSet<BillingSumary> BillingSumary { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>().Property(p => p.PricePerRequest).HasPrecision(10, 6);

            modelBuilder.Entity<BillingSumary>().Property(p => p.PricePerRequest).HasPrecision(10, 6);

            modelBuilder.Entity<Billings>().Property(p => p.TotalPrice).HasPrecision(10, 6);


            base.OnModelCreating(modelBuilder);
        }
    }
}
