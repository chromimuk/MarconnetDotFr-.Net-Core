using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class WorkModelXmlDao : IWorkModelDao
    {
        private readonly XElement _element;

        public WorkModelXmlDao(XDocument xDocument)
        {
            _element = xDocument.Element("work");
        }

        public string GetContent()
        {
            return _element.Element("content").Value;
        }

        public string GetImage()
        {
            return _element.Element("cover").Element("image").Value;
        }

        public string GetLink()
        {
            return _element.Element("cover").Element("link") == null ? "" : _element.Element("cover").Element("link").Value;
        }

        public string GetPeriod()
        {
            return _element.Element("cover").Element("period").Value;
        }

        public string GetSubtitle()
        {
            return _element.Element("cover").Element("subtitle").Value;
        }

        public string GetTitle()
        {
            return _element.Element("cover").Element("title").Value;
        }

        public List<string> GetScreenshots()
        {
            var elems = _element.Descendants("screenshots").Descendants("screenshot");
            List<string> screenshots = new List<string>();
            foreach (XElement screenshot in elems)
            {
                screenshots.Add(screenshot.Value);
            }
            return screenshots;
        }
    }
}