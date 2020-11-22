using LastFM.AspNetCore.Stats;
using LastFM.AspNetCore.Stats.Entities;
using LastFM.AspNetCore.Stats.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr.Core.Services
{
    public class LastFMStatsService : ILastFMStatsService
    {
        private readonly LastFMStatsController _controller;

        public LastFMStatsService(LastFMCredentials credentials)
        {
            _controller = new LastFMStatsController(credentials);
        }

        public Task<LastFMUser> GetUserInfo(string username)
        {
            return _controller.GetUserInfo(username);
        }

        public Task<IEnumerable<Track>> GetLovedTracks(string username, int limit)
        {
            return _controller.GetUserLovedTracks(username, limit);
        }

        public Task<IEnumerable<Track>> GetRecentTracks(string username, int limit)
        {
            return _controller.GetUserRecentTracks(username, limit);
        }

        public Task<IEnumerable<Album>> GetTopAlbums(string username, int limit)
        {
            return _controller.GetUserTopAlbums(username, limit);
        }

        public Task<IEnumerable<Artist>> GetTopArtists(string username, int limit)
        {
            return _controller.GetUserTopArtists(username, limit);
        }

        public Task<IEnumerable<Track>> GetTopTracks(string username, int limit)
        {
            return _controller.GetUserTopTracks(username, limit);
        }
    }
}
