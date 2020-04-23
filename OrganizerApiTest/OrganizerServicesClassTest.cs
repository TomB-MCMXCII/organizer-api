using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizerApi.Models;
using OrganizerApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerApiTest
{
    [TestClass]
    public class OrganizerServicesClassTest
    {        
        [TestMethod]
        public void CreatesTodoEntry()
        {
            OrganizerService organizerService = OrganizerService.GetInstance();
            
            organizerService.CreateTodoEntry("25-07-2020", "Celebrate my birthday");

            var day = organizerService.year.days.Find(x => x.date == DateTime.Parse("25-07-2020"));
            Assert.IsTrue(day.toDoEntries.Count == 1);
        }
        [TestMethod]
        public void CreatesScheduleEntry()
        {
            OrganizerService organizerService = OrganizerService.GetInstance();
            organizerService.CreateScheduleEntry("25-07-2020","10:00", "12:00", "dentist");
            var day = organizerService.year.days.Find(x => x.date == DateTime.Parse("25-07-2020"));
            Assert.IsTrue(day.scheduleEntries.Count == 1);
        }
    }
}
