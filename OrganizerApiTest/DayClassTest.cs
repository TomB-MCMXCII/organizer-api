using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizerApi.Models;
using System;

namespace OrganizerApiTest
{
    [TestClass]
    public class DayClassTest
    {
        [TestMethod]
        public void TestAddToDoEntryMethod()
        {
            Day day = new Day();
            day.AddToDoEntry("");
            int entryCount = day.toDoEntries.Count;
            Assert.AreEqual(1, entryCount);
        }
        [TestMethod]
        public void TestAddScheduleEntryMethod()
        {
            Day day = new Day();
          
            day.AddScheduleEntry("10:00","12:00","dentist");
            int entryCount = day.scheduleEntries.Count;
            Assert.AreEqual(1, entryCount);
        }
    }
}
