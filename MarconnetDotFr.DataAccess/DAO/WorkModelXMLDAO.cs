using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class WorkModelXMLDAO : IWorkModelDAO
    {
        private XElement element;

        public WorkModelXMLDAO(XDocument xDocument)
        {
            element = xDocument.Element("work");
        }

        public string GetContent()
        {
            return element.Element("content").Value;
        }

        public string GetImage()
        {
            return element.Element("cover").Element("image").Value;
        }

        public string GetLink()
        {
            return element.Element("cover").Element("link") == null ? "" : element.Element("cover").Element("link").Value;
        }

        public string GetPeriod()
        {
            return element.Element("cover").Element("period").Value;
        }

        public string GetSubtitle()
        {
            return element.Element("cover").Element("subtitle").Value;
        }

        public string GetTitle()
        {
            return element.Element("cover").Element("title").Value;
        }

        public List<string> GetScreenshots()
        {
            var elems = element.Descendants("screenshots").Descendants("screenshot");
            List<string> screenshots = new List<string>();
            foreach (XElement screenshot in elems)
            {
                screenshots.Add(screenshot.Value);
            }
            return screenshots;
        }
    }
}