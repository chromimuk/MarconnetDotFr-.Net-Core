using LastFM.AspNetCore.Stats.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr.Core.Services
{
    public interface ILastFMStatsService
    {
        Task<LastFMUser> GetUserInfo(string username);
        Task<IEnumerable<Track>> GetLovedTracks(string username, int limit);
        Task<IEnumerable<Track>> GetRecentTracks(string username, int limit);
        Task<IEnumerable<Album>> GetTopAlbums(string username, int limit);
        Task<IEnumerable<Artist>> GetTopArtists(string username, int limit);
        Task<IEnumerable<Track>> GetTopTracks(string username, int limit);
    }
}
