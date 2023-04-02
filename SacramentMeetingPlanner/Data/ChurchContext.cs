using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class ChurchContext : DbContext
    {
        public ChurchContext (DbContextOptions<ChurchContext> options)
            : base(options)
        {
        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().ToTable("Meetings");
            modelBuilder.Entity<Assignments>().ToTable("Assignments");
            modelBuilder.Entity<Speaker>().ToTable("Speakers");
        }
    }
}
