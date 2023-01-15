using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class SeasonModelXmlDao : XmlDao, ISeasonModelDao
    {
        public SeasonModelXmlDao(XElement e) : base(e)
        {
        }

        public int? GetAttendance()
        {
            return GetIntValue("attendance");
        }

        public string GetCoupeDeFrance()
        {
            return GetStringValue("coupedefrance");
        }

        public string GetCoupeDeLaLigue()
        {
            return GetStringValue("coupedelaligue");
        }

        public string GetDescription()
        {
            return GetStringValue("description");
        }

        public string GetDivision()
        {
            return GetStringValue("division");
        }

        public string GetEurope()
        {
            return GetStringValue("europe");
        }

        public string GetNotes()
        {
            return GetStringValue("notes");
        }

        public int? GetRanking()
        {
            return GetIntValue("ranking");
        }
    }
}
