using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
using System.Collections.Generic;

namespace MarconnetDotFr.DataAccess.Repositories.Interfaces
{
    public interface IFootyRepository
    {
        IEnumerable<SeasonModel> GetSeasons(string club);
    }
}
