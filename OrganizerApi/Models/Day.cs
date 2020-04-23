using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class Day
    {     
        public List<ToDoEntry> toDoEntries { get; set; }
        public Dictionary<DateTime, ScheduleEntry> scheduleEntries {get;set;}
        public DateTime date { get; set; }
        public int weekNumber { get; set; }
       
        public Day(double offset = 0)
        {
            date = DateTime.Today.AddDays(offset);
            weekNumber = GetIso8601WeekOfYear(date);
            toDoEntries = new List<ToDoEntry>();
            scheduleEntries = new Dictionary<DateTime, ScheduleEntry>();
        }
        public void AddToDoEntry(ToDoEntry toDoEntry)
        {
            toDoEntries.Add(toDoEntry);
        }
        public void AddScheduleEntry(DateTime startTime,ScheduleEntry scheduleEntry)
        {
            scheduleEntries.Add(startTime,scheduleEntry);
        }
        private int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
