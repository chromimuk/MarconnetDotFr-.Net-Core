using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System;

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
            switch(strDivision)
            {
                case "D1":
                case "D1-N":
                case "D1-B":
                    return Division.D1;        
                case "D2":
                case "D2-A":
                case "D2-FrancheComte":
                    return Division.D2;    
                case "D3":
                    return Division.D3;
                default:
                    throw new ArgumentException(strDivision);
            }
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