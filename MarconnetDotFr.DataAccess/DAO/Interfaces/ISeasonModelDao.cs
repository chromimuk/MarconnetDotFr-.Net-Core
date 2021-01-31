using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;

namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface ISeasonModelDao
    {
        string GetDescription();
        string GetDivision();
        int? GetRanking();
        int? GetAttendance();
        string GetCoupeDeFrance();
        string GetCoupeDeLaLigue();
        string GetEurope();
        string GetNotes();
    }
}