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
        public DbSet<Hymn> Hymns { get; set; }
        //public DbSet<Selection> Selections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Selection>().ToTable("Selections");
            modelBuilder.Entity<Hymn>().ToTable("Hymns");
            modelBuilder.Entity<Meeting>().ToTable("Meetings");
            modelBuilder.Entity<Assignments>().ToTable("Assignments");
            modelBuilder.Entity<Speaker>().ToTable("Speakers");
        }

        public DbSet<SacramentMeetingPlanner.Models.Hymn> Hymn { get; set; }
    }
}
