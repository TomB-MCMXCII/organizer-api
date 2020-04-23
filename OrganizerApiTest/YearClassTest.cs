using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerApiTest
{
    [TestClass]
    public class YearClassTest
    {
        [TestMethod]
        public void YearShouldGenerateProperCountOfDaysLeftInAYear()
        {
            Year year = new Year();
            DateTime now = DateTime.Now;
            DateTime end = new DateTime(now.Year + 1, 1, 1);
            int daysLeftInYear = (int)(end - now).TotalDays;
            Assert.AreEqual(daysLeftInYear, year.days.Count);
        }
    }
}
