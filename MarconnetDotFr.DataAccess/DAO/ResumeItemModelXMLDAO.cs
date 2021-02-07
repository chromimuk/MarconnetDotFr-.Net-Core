using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class ResumeItemModelXmlDao : IResumeItemModelDao
    {
        private readonly XElement _element;

        public ResumeItemModelXmlDao(XElement e)
        {
            _element = e;
        }

        public string GetDescription()
        {
            return XmlHelper.GetValue(_element, "description");
        }

        public string GetLocation()
        {
            return XmlHelper.GetValue(_element, "location");
        }

        public string GetShortLocation()
        {
            return XmlHelper.GetValue(_element, "short-location");
        }

        public string GetTitle()
        {
            return XmlHelper.GetValue(_element, "title");
        }

        public string GetShortTitle()
        {
            return XmlHelper.GetValue(_element, "short-title");
        }

        public string GetImage()
        {
            return XmlHelper.GetValue(_element, "image");
        }

        public string GetTech()
        {
            return XmlHelper.GetValue(_element, "tech");
        }

        public string GetNote()
        {
            return XmlHelper.GetValue(_element, "note");
        }
    }
}