using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
using MarconnetDotFr.Core.Models.FootyStats.WorldCup;
using System.Collections.Generic;

namespace MarconnetDotFr.DataAccess.Repositories.Interfaces
{
    public interface IFootyRepository
    {
        IEnumerable<SeasonModel> GetSeasons(string club);

        IEnumerable<WorldCupGame> GetWorldCupGames();
    }
}
