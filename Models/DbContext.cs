using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
// using Gladiator.Database;
// using GladiatorContainingUserClass;
// using GladiatorContainingBookingClass;


// using Gladiator.ViewModel;

namespace Gladiator.Models;

public class GDbContext : DbContext
{
    public GDbContext(DbContextOptions<GDbContext> options) : base(options)
    {
    }

    
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships, constraints, etc.

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.UserCredentials)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserID);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Service)
            .WithMany(s => s.Bookings)
            .HasForeignKey(b => b.ServiceID);

        modelBuilder.Entity<Payment>()
    .HasOne(p => p.User)
    .WithMany(u => u.Payments)
    .HasForeignKey(p => p.UserId);

modelBuilder.Entity<Payment>()
    .HasOne(p => p.Booking)
    .WithMany(b => b.Payments)
    .HasForeignKey(p => p.BookingId);



        // Add more configurations as needed...

        base.OnModelCreating(modelBuilder);
    }
}
