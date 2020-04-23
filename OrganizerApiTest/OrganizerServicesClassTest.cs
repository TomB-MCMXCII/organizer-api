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
        public void CreatesTodoItem()
        {
            OrganizerServices organizerServices = OrganizerServices.GetInstance();
            
            organizerServices.CreateTodo("25-07-2020", "Celebrate my birthday");

            var day = organizerServices.year.days.Find(x => x.date == DateTime.Parse("25-07-2020"));
            Assert.IsTrue(day.toDoEntries.Count == 1);
        }
    }
}
