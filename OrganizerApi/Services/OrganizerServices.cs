using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Services
{
    public class OrganizerServices
    {
        private OrganizerServices() { }
        private static OrganizerServices organizerServicesInstance = new OrganizerServices();
        public static OrganizerServices GetInstance() => organizerServicesInstance;

        public Year year = new Year();

        public Year GetCurrentYear()
        {
            return year;
        }
        public void CreateTodo(string date, string text)
        {
            var day = year.days.Find(x => x.date == DateTime.Parse(date));
            day.toDoEntries.Add(new ToDoEntry(text));
        }
    }
}
