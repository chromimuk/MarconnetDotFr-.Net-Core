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
    }
}