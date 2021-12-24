using System;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        // Stores User Entity
        public DbSet<User> Users { get; set; }

        // Stores Event Entity
        public DbSet<Event> Events { get; set; }
    }
}