using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class WorkItemModelXmlDao : IWorkItemModelDao
    {
        private readonly XElement _element;

        public WorkItemModelXmlDao(XElement e)
        {
            _element = e;
        }

        public string GetAlias()
        {
            return _element.Element("alias").Value;
        }

        public string GetDescription()
        {
            return _element.Element("description").Value;
        }

        public string GetLink()
        {
            return _element.Element("link").Value;
        }

        public string GetSubtitle()
        {
            return _element.Element("subtitle").Value;
        }

        public string GetTitle()
        {
            return _element.Element("title").Value;
        }
    }
}