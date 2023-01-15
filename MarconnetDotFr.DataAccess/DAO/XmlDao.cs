using MarconnetDotFr.Core.Helpers;
using System;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public abstract class XmlDao
    {
        private readonly XElement _element;

        public XmlDao(XElement e)
        {
            _element = e;
        }

        protected string GetStringValue(string name)
        {
            return XmlHelper.GetValue(_element, name);
        }

        protected int GetIntValue(string name)
        {
            return XmlHelper.GetIntValue(_element, name) ?? 0;
        }

        protected DateTime GetDateTimeValue(string name)
        {
            return XmlHelper.GetDateValue(_element, name);
        }

        protected bool GetBoolValue(string name)
        {
            return XmlHelper.GetBoolValue(_element, name);
        }
    }
}
