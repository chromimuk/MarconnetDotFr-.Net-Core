using LastFM.AspNetCore.Stats.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr.Core.Services
{
    public interface ILastFMStatsService
    {
        Task<LastFMUser> GetUserInfo(string username);
        Task<IEnumerable<Track>> GetLovedTracks(string username);
        Task<IEnumerable<Track>> GetRecentTracks(string username);
        Task<IEnumerable<Album>> GetTopAlbums(string username);
        Task<IEnumerable<Artist>> GetTopArtists(string username);
        Task<IEnumerable<Track>> GetTopTracks(string username);
    }
}
