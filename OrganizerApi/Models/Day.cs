using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class Day
    {
        public Day()
        {
            toDoEntries = new List<ToDoEntry>();
            scheduleEntries = new Dictionary<DateTime, ScheduleEntry>();
        }
        public List<ToDoEntry> toDoEntries { get; set; }
        public Dictionary<DateTime, ScheduleEntry> scheduleEntries {get;set;}
        public void AddToDoEntry(ToDoEntry toDoEntry)
        {
            toDoEntries.Add(toDoEntry);
        }
        public void AddScheduleEntry(DateTime startTime,ScheduleEntry scheduleEntry)
        {
            scheduleEntries.Add(startTime,scheduleEntry);
        }
    }
}
