using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.DAO;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using MarconnetDotFr.DataAccess.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace MarconnetDotFr.UnitTests.DataAccess.Mappers
{
    [TestClass]
    public class ResumeMapperUnitTests
    {
        [TestMethod]
        public void ResumeMapperUnitTests_ToResumeItemModel()
        {
            // Arrange
            const string imageValue = "a";
            const string titleValue = "b";
            const string shortTitleValue = "c";
            const string locationValue = "d";
            const string shortLocationValue = "e";
            const string descriptionValue = "f";
            const string techValue = "g";

            XElement element = new XElement(
                "Root",
                new XElement("image", imageValue),
                new XElement("title", titleValue),
                new XElement("short-title", shortTitleValue),
                new XElement("location", locationValue),
                new XElement("short-location", shortLocationValue),
                new XElement("description", descriptionValue),
                new XElement("tech", techValue)
            );
            IResumeItemModelDao dao = new ResumeItemModelXmlDao(element);

            // Act
            ResumeItemModel model = ResumeMapper.ToResumeItemModel(dao);

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(imageValue, model.Image);
            Assert.AreEqual(titleValue, model.Title);
            Assert.AreEqual(shortTitleValue, model.ShortTitle);
            Assert.AreEqual(locationValue, model.Location);
            Assert.AreEqual(shortLocationValue, model.ShortLocation);
            Assert.AreEqual(descriptionValue, model.Description);
            Assert.AreEqual(techValue, model.Tech);
        }

        [TestMethod]
        public void ResumeMapperUnitTests_ToWorkItemModel()
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
            IWorkItemModelDao dao = new WorkItemModelXmlDao(element);

            // Act
            WorkItemModel model = ResumeMapper.ToWorkItemModel(dao);

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(titleValue, model.Title);
            Assert.AreEqual(aliasValue, model.Alias);
            Assert.AreEqual(linkValue, model.Link);
            Assert.AreEqual(subtitleValue, model.Subtitle);
            Assert.AreEqual(descriptionValue, model.Description);
        }

        [TestMethod]
        public void ResumeMapperUnitTests_ToWorkModel()
        {
            // Arrange
            const string titleValue = "a";
            const string linkValue = "c";
            const string subtitleValue = "d";
            const string imageValue = "e";
            const string periodValue = "f";
            const string contentValue = "g";

            XElement coverElement = new XElement(
                "cover",
                new XElement("title", titleValue),
                new XElement("link", linkValue),
                new XElement("subtitle", subtitleValue),
                new XElement("image", imageValue),
                new XElement("period", periodValue)
            );
            XElement workElement = new XElement("work", coverElement, new XElement("content", contentValue));
            XDocument document = new XDocument(workElement);
            IWorkModelDao dao = new WorkModelXmlDao(document);

            // Act
            WorkModel model = ResumeMapper.ToWorkModel(dao);

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(titleValue, model.Title);
            Assert.AreEqual(linkValue, model.Link);
            Assert.AreEqual(subtitleValue, model.Subtitle);
            Assert.AreEqual(imageValue, model.Image);
            Assert.AreEqual(periodValue, model.Period);
            Assert.AreEqual(contentValue, model.Content);
        }
    }
}