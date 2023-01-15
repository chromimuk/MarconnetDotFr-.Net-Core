using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class WorkItemModelXmlDao : XmlDao, IWorkItemModelDao
    {
        public WorkItemModelXmlDao(XElement e) : base(e)
        {
        }

        public string GetAlias()
        {
            return GetStringValue("alias");
        }

        public string GetDescription()
        {
            return GetStringValue("description");
        }

        public string GetLink()
        {
            return GetStringValue("link");
        }

        public string GetSubtitle()
        {
            return GetStringValue("subtitle");
        }

        public string GetTitle()
        {
            return GetStringValue("title");
        }

        public string GetImage()
        {
            return GetStringValue("image");
        }

        public bool GetIsHighlighted()
        {
            return GetBoolValue("isHighlighted");
        }
    }
}