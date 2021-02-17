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
            return strCupPerformance switch
            {
                "Vainqueur" => CupPerformance.Winner,
                "Finale" => CupPerformance.Final,
                "1/2f" => CupPerformance.SemiFinals,
                "1/4f" => CupPerformance.QuarterFinals,
                "1/8f" => CupPerformance.RoundOfEight,
                "1/16f" => CupPerformance.RoundOfSixteen,
                "1/32f" => CupPerformance.RoundOfThirtyTwo,
                _ => CupPerformance.Unknown,
            };
        }
    }
}