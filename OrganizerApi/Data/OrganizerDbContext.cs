using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using OrganizerApi.Core.Models;
using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Data
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
    }
}
