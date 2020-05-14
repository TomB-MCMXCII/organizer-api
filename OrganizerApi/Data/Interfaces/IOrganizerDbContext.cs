using Microsoft.EntityFrameworkCore;
using OrganizerApi.Core.Models;
using OrganizerApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizerApi.Data
{
    public interface IOrganizerDbContext
    {
        DbSet<Day> Days { get; set; }
        DbSet<ScheduleEntry> ScheduleEntries { get; set; }
        DbSet<ToDo> ToDoEntries { get; set; }
        DbSet<Note> Notes { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}