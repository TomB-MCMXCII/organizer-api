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
        public void AddToDoEntry(string text)
        {
            toDoEntries.Add(new ToDoEntry() { Text = text});
        }
        public void AddScheduleEntry(string startTime,string endTime,string text)
        {
            scheduleEntries.Add(DateTime.Parse(startTime),
                new ScheduleEntry() { 
                    startTime = DateTime.Parse(startTime),
                    endTime = DateTime.Parse(endTime),
                    text = text
                });
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
