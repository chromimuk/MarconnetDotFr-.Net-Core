using System;

namespace MarconnetDotFr.Core.Models.FootyStats
{
    public class SeasonModel
    {
        public string season { get; set; }
        public Division division { get; set; }
        public int? attendance { get; set; }
        public int? ranking { get; set; }
        public CupPerformance coupedefrance { get; set; }
        public CupPerformance coupedelaligue { get; set; }
        public string europe { get; set; }
        public string notes { get; set; }

        #region ComputedProperties
        public int? rankingForChart => CalculateAllDivisionRanking();
        public int? coupeDeFranceForChart => CalculateCupRanking(coupedefrance);
        public int? coupeDeLaLigueForChart => CalculateCupRanking(coupedelaligue);
        public string strDivision => division == Division.D1 ? "D1" : "D2";
        public string strCoupeDeFrance => ToStrCupPerformance(coupedefrance);
        public string strCoupeDeLaLigue => ToStrCupPerformance(coupedelaligue);
        #endregion ComputedProperties

        private int? CalculateAllDivisionRanking()
        {
            // basically reverse the ranking (1 becomes the highest, 20 the lowest) and add 20 if in first division 

            var rank = 21 - ranking;

            if (division == Division.D1)
            {
                rank += 20;
            }

            return rank;
        }

        private int? CalculateCupRanking(CupPerformance cupPerformance)
        {
            int countCupPerformance = Enum.GetNames(typeof(CupPerformance)).Length;

            switch (cupPerformance)
            {
                case CupPerformance.Winner:
                    return countCupPerformance;
                case CupPerformance.Final:
                    return countCupPerformance - 1;
                case CupPerformance.SemiFinals:
                    return countCupPerformance - 2;
                case CupPerformance.QuarterFinals:
                    return countCupPerformance - 3;
                case CupPerformance.RoundOfEight:
                    return countCupPerformance - 4;
                case CupPerformance.RoundOfSixteen:
                    return countCupPerformance - 5;
                case CupPerformance.RoundOfThirtyTwo:
                    return countCupPerformance - 6;
                default:
                    return null;
            }
        }

        private string ToStrCupPerformance(CupPerformance cupPerformance)
        {
            switch (cupPerformance)
            {
                case CupPerformance.Winner:
                    return "Vainqueur";
                case CupPerformance.Final:
                    return "Finaliste";
                case CupPerformance.SemiFinals:
                    return "Demi-finaliste";
                case CupPerformance.QuarterFinals:
                    return "Quart-de-finaliste";
                case CupPerformance.RoundOfEight:
                    return "8eme de finale";
                case CupPerformance.RoundOfSixteen:
                    return "16eme de finale";
                case CupPerformance.RoundOfThirtyTwo:
                    return "32eme de finale";
                default:
                    return null;
            }
        }
    }

    public enum Division
    {
        D1,
        D2
    }

    public enum CupPerformance
    {
        RoundOfThirtyTwo = 32,
        RoundOfSixteen = 16,
        RoundOfEight = 8,
        QuarterFinals = 4,
        SemiFinals = 2,
        Final = 1,
        Winner = 0,
        Unknown = -1
    }
}