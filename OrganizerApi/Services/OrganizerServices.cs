using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Services
{
    public class OrganizerService
    {
        private OrganizerService() { }
        private static OrganizerService organizerServicesInstance = new OrganizerService();
        public static OrganizerService GetInstance() => organizerServicesInstance;

        public Year year = new Year();

        public Year GetCurrentYear()
        {
            return year;
        }
        public void CreateTodoEntry(string date, string text)
        {
            var day = year.days.Find(x => x.date == DateTime.Parse(date));
            day.AddToDoEntry(text);
        }
        public void CreateScheduleEntry(string date, string startTime, string endTime, string text)
        {
            var day = year.days.Find(x => x.date == DateTime.Parse(date));
            day.AddScheduleEntry(startTime, endTime, text);
        }
    }
}
