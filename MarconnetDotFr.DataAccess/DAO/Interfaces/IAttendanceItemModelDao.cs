namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IAttendanceItemModelDao
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