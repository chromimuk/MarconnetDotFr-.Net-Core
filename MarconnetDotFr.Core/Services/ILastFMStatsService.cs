using LastFM.AspNetCore.Stats.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr.Core.Services
{
    public interface ILastFMStatsService
    {
        Task<LastFMUser> GetUserInfo();
        Task<IEnumerable<Track>> GetLovedTracks();
        Task<IEnumerable<Track>> GetRecentTracks();
        Task<IEnumerable<Album>> GetTopAlbums();
        Task<IEnumerable<Artist>> GetTopArtists();
        Task<IEnumerable<Track>> GetTopTracks();
    }
}
