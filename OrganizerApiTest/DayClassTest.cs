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
            ToDoEntry toDoEntry = new ToDoEntry();
            day.AddToDoEntry(toDoEntry);
            int entryCount = day.toDoEntries.Count;
            Assert.AreEqual(1, entryCount);
        }
        [TestMethod]
        public void TestAddScheduleEntryMethod()
        {
            Day day = new Day();
            ScheduleEntry scheduleEntry = new ScheduleEntry();
            DateTime startTime = new DateTime();
            day.AddScheduleEntry(startTime,scheduleEntry);
            int entryCount = day.scheduleEntries.Count;
            Assert.AreEqual(1, entryCount);
        }
    }
}
