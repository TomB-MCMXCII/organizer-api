using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class Year
    {
        public List<Day> days { get; set; }
        public Year()
        {
            days = new List<Day>();
            DateTime now = DateTime.Now;
            DateTime end = new DateTime(now.Year + 1, 1, 1);
            int daysLeftInYear = (int)(end - now).TotalDays;
            for(int i = 0; i < daysLeftInYear;i++)
            {
                days.Add(new Day(i));
            }
        }
    }
}
