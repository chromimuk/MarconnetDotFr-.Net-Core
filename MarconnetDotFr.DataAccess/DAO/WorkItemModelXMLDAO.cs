using MarconnetDotFr.Core.Helpers;
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
            return XmlHelper.GetValue(_element, "alias");
        }

        public string GetDescription()
        {
            return XmlHelper.GetValue(_element, "description");
        }

        public string GetLink()
        {
            return XmlHelper.GetValue(_element, "link");
        }

        public string GetSubtitle()
        {
            return XmlHelper.GetValue(_element, "subtitle");
        }

        public string GetTitle()
        {
            return XmlHelper.GetValue(_element, "title");
        }

        public string GetImage()
        {
            return XmlHelper.GetValue(_element, "image");
        }

        public bool GetIsHighlighted()
        {
            return XmlHelper.GetBoolValue(_element, "isHighlighted");
        }
    }
}