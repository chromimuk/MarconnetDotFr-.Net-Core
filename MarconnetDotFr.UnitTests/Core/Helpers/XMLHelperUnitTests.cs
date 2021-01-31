using MarconnetDotFr.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace MarconnetDotFr.UnitTests.Core.Helpers
{
    [TestClass]
    public class ResumeMapperUnitTests
    {
        [TestMethod]
        public void XMLHelperUnitTests_GetValue()
        {
            // Arrange
            const string titleValue = "a";
            const string aliasValue = "b";
            const string linkValue = "c";
            const string subtitleValue = "d";
            const string descriptionValue = "e";

            XElement element = new XElement(
                "Root",
                new XElement("title", titleValue),
                new XElement("alias", aliasValue),
                new XElement("link", linkValue),
                new XElement("subtitle", subtitleValue),
                new XElement("description", descriptionValue)
            );

            // Act
            string result = XmlHelper.GetValue(element, "title");

            // Assert
            Assert.AreEqual(titleValue, result);
        }

        [TestMethod]
        public void XMLHelperUnitTests_GetIntValue()
        {
            // Arrange
            int number = 123;
            int? nullableNumber = 456;
            int? nullNumber = null;
            string notANumber = "a";

            XElement element = new XElement(
                "Root",
                new XElement("number", number),
                new XElement("nullableNumber", nullableNumber),
                new XElement("nullNumber", nullNumber),
                new XElement("notANumber", notANumber)
            );

            // Act
            int? resultNumber = XmlHelper.GetIntValue(element, "number");
            int? resultNullableNumber = XmlHelper.GetIntValue(element, "nullableNumber");
            int? resultNullNumber = XmlHelper.GetIntValue(element, "nullNumber");
            int? resultNotANumber = XmlHelper.GetIntValue(element, "notANumber");

            // Assert
            Assert.AreEqual(number, resultNumber);
            Assert.AreEqual(nullableNumber, resultNullableNumber);
            Assert.AreEqual(nullNumber, resultNullNumber);
            Assert.IsNull(resultNotANumber);
        }
    }
}