using System.Xml.Linq;

namespace MarconnetDotFr.Core.Helpers
{
    public static class XmlHelper
    {
        public static string GetValue(XElement element, string name)
        {
            return element.Element(name) == null ? "" : element.Element(name).Value;
        }
    }
}