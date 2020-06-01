using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class ResumeItemModelXMLDAO : IResumeItemModelDAO
    {
        private XElement element;

        public ResumeItemModelXMLDAO(XElement e)
        {
            element = e;
        }

        public string GetDescription()
        {
            return XMLHelper.GetValue(element, "description");
        }

        public string GetLocation()
        {
            return XMLHelper.GetValue(element, "location");
        }

        public string GetShortLocation()
        {
            return XMLHelper.GetValue(element, "short-location");
        }

        public string GetTitle()
        {
            return XMLHelper.GetValue(element, "title");
        }

        public string GetShortTitle()
        {
            return XMLHelper.GetValue(element, "short-title");
        }

        public string GetImage()
        {
            return XMLHelper.GetValue(element, "image");
        }

        public string GetTech()
        {
            return XMLHelper.GetValue(element, "tech");
        }
    }
}