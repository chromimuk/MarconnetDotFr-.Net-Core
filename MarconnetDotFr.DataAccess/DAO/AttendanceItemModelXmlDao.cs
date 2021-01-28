using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class AttendanceItemModelXmlDao : IAttendanceItemModelDao
    {
        private readonly XElement _element;

        public AttendanceItemModelXmlDao(XElement e)
        {
            _element = e;
        }

        public int? GetAttendance()
        {
            string strAttendance = XmlHelper.GetValue(_element, "attendance");

            if (int.TryParse(strAttendance, out int attendance))
            {
                return attendance;
            }
            else
            {
                return null;
            }

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
            string strRanking = XmlHelper.GetValue(_element, "ranking");

            if (int.TryParse(strRanking, out int attendance))
            {
                return attendance;
            }
            else
            {
                return null;
            }
        }
    }
}
