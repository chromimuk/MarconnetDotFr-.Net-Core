using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
using MarconnetDotFr.DataAccess.DAO.Interfaces;

namespace MarconnetDotFr.DataAccess.Mappers
{
    public static class FootyMapper
    {
        public static SeasonModel ToSeasonItemModel(ISeasonModelDao dao)
        {
            return new SeasonModel()
            {
                season = dao.GetDescription(),
                division = ToDivision(dao.GetDivision()),
                attendance = dao.GetAttendance(),
                ranking = dao.GetRanking(),
                coupedefrance = ToCupPerformance(dao.GetCoupeDeFrance()),
                coupedelaligue = ToCupPerformance(dao.GetCoupeDeLaLigue()),
                europe = dao.GetEurope(),
                notes = dao.GetNotes()
            };
        }

        private static Division ToDivision(string strDivision)
        {
            return strDivision.Contains("D1") ? Division.D1 : Division.D2;
        }

        private static CupPerformance ToCupPerformance(string strCupPerformance)
        {
            switch (strCupPerformance)
            {
                case "Vainqueur":
                    return CupPerformance.Winner;
                case "Finale":
                    return CupPerformance.Final;
                case "1/2f":
                    return CupPerformance.SemiFinals;
                case "1/4f":
                    return CupPerformance.QuarterFinals;
                case "1/8f":
                    return CupPerformance.RoundOfEight;
                case "1/16f":
                    return CupPerformance.RoundOfSixteen;
                case "1/32f":
                    return CupPerformance.RoundOfThirtyTwo;
                default:
                    return CupPerformance.Unknown;
            }
        }
    }
}