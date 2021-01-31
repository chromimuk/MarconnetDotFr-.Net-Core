using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class SeasonModelXmlDao : ISeasonModelDao
    {
        private readonly XElement _element;

        public SeasonModelXmlDao(XElement e)
        {
            _element = e;
        }

        public int? GetAttendance()
        {
            return XmlHelper.GetIntValue(_element, "attendance");
        }

        public string GetCoupeDeFrance()
        {
            return XmlHelper.GetValue(_element, "coupedefrance");
        }

        public string GetCoupeDeLaLigue()
        {
            return XmlHelper.GetValue(_element, "coupedelaligue");
        }

        public string GetDescription()
        {
            return XmlHelper.GetValue(_element, "description");
        }

        public string GetDivision()
        {
            return XmlHelper.GetValue(_element, "division");
        }

        public string GetEurope()
        {
            return XmlHelper.GetValue(_element, "europe");
        }

        public string GetNotes()
        {
            return XmlHelper.GetValue(_element, "notes");
        }

        public int? GetRanking()
        {
            return XmlHelper.GetIntValue(_element, "ranking");
        }
    }
}
