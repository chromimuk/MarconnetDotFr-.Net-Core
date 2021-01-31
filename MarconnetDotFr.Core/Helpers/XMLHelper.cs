using System.Xml.Linq;

namespace MarconnetDotFr.Core.Helpers
{
    public static class XmlHelper
    {
        public static string GetValue(XElement element, string name)
        {
            return element.Element(name) == null ? "" : element.Element(name).Value;
        }

        public static int? GetIntValue(XElement element, string name)
        {
            string strValue = GetValue(element, name);

            if (int.TryParse(strValue, out int value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}