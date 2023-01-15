using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class ResumeItemModelXmlDao : XmlDao, IResumeItemModelDao
    {
        public ResumeItemModelXmlDao(XElement e) : base(e)
        {
        }

        public string GetDescription()
        {
            return GetStringValue("description");
        }

        public string GetLocation()
        {
            return GetStringValue("location");
        }

        public string GetShortLocation()
        {
            return GetStringValue("short-location");
        }

        public string GetTitle()
        {
            return GetStringValue("title");
        }

        public string GetShortTitle()
        {
            return GetStringValue("short-title");
        }

        public string GetImage()
        {
            return GetStringValue("image");
        }

        public string GetTech()
        {
            return GetStringValue("tech");
        }

        public string GetNote()
        {
            return GetStringValue("note");
        }
    }
}