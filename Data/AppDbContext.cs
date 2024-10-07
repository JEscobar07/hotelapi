using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Seeders;
using Microsoft.EntityFrameworkCore;

namespace hotelapi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RoomTypesSeeder.Seed(modelBuilder);
            RoomSeeder.Seed(modelBuilder, 50);
        }
    }
}