using System;

namespace MarconnetDotFr.Core.Helpers
{
    public class DateHelper
    {
        public static int GetYearDifference(DateTime d1, DateTime d2)
        {
            int yearDifferences = d1.Year - d2.Year;
            if (d2.Date > d1.AddYears(-yearDifferences))
                yearDifferences--;

            return yearDifferences;
        }
    }
}