using System;
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

        public static bool GetBoolValue(XElement element, string name)
        {
            string strValue = GetValue(element, name);

            if (bool.TryParse(strValue, out bool value))
            {
                return value;
            }
            else
            {
                throw new InvalidCastException("Could not convert value to boolean");
            }
        }

        public static DateTime GetDateValue(XElement element, string name)
        {
            string strValue = GetValue(element, name);

            if (DateTime.TryParse(strValue, out DateTime value))
            {
                return value;
            }
            else
            {
                throw new InvalidCastException("Could not convert value to datime");
            }
        }
    }
}