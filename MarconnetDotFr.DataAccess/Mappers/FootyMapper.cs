using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.DAO.Interfaces;

namespace MarconnetDotFr.DataAccess.Mappers
{
    public static class FootyMapper
    {
        public static SeasonItemModel ToSeasonItemModel(ISeasonItemModelDao dao)
        {
            return new SeasonItemModel()
            {
                season = dao.GetDescription(),
                division = dao.GetDivision(),
                attendance = dao.GetAttendance(),
                ranking = dao.GetRanking(),
                coupedefrance = dao.GetCoupeDeFrance(),
                coupedelaligue = dao.GetCoupeDeLaLigue(),
                europe = dao.GetEurope(),
                notes = dao.GetNotes()
            };
        }
    }
}