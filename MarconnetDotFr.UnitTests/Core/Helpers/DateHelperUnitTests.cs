using MarconnetDotFr.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarconnetDotFr.UnitTests.Core.Helpers
{
    [TestClass]
    public class DateHelperUnitTests
    {
        [TestMethod]
        public void DateHelperUnitTests_GetYearDifference_FirstDateNewer()
        {
            // Arrange
            int year1 = 1990;
            int year2 = 2000;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year2, 01, 01);

            // Act
            int actualDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(year1 - year2, actualDifference);
        }

        [TestMethod]
        public void DateHelperUnitTests_GetYearDifference_FirstDateOlder()
        {
            // Arrange
            int year1 = 1990;
            int year2 = 2000;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year2, 01, 01);

            // Act
            int actualDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(year1 - year2, actualDifference);
        }

        [TestMethod]
        public void DateHelperUnitTests_GetYearDifference_SameDate()
        {
            // Arrange
            int year1 = 1990;
            DateTime d1 = new DateTime(year1, 01, 01);
            DateTime d2 = new DateTime(year1, 01, 01);

            // Act
            int actualDifference = DateHelper.GetYearDifference(d1, d2);

            // Assert
            Assert.AreEqual(0, actualDifference);
        }
    }
}