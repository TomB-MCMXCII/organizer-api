using Microsoft.EntityFrameworkCore;
using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Repository
{
    public class OrganizerDbContext : DbContext, IOrganizerDbContext
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<ScheduleEntry> ScheduleEntries { get; set; }
        public DbSet<ToDo> ToDoEntries { get; set; }
        public DbSet<Note> Notes { get; set; }

        public OrganizerDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasOne(b => b.Day)
                .WithMany(a => a.ToDoEntries)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Note>()
               .HasOne(b => b.Day)
               .WithMany(a => a.Notes)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ScheduleEntry>()
               .HasOne(b => b.Day)
               .WithMany(a => a.ScheduleEntries)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
