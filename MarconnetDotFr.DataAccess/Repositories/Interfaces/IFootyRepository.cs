using MarconnetDotFr.Core.Models;
using System.Collections.Generic;

namespace MarconnetDotFr.DataAccess.Repositories.Interfaces
{
    public interface IFootyRepository
    {
        IEnumerable<AttendanceItemModel> GetAttendances(string club);
    }
}
