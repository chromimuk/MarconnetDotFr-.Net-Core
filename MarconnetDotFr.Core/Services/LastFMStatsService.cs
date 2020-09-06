using LastFM.AspNetCore.Stats;
using LastFM.AspNetCore.Stats.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr.Core.Services
{
    public class LastFMStatsService : ILastFMStatsService
    {
        private readonly LastFMStatsController _controller;
        private readonly string _username;

        public LastFMStatsService(string username, LastFMCredentials credentials)
        {
            _controller = new LastFMStatsController(credentials);
            _username = username;
        }

        public Task<LastFMUser> GetUserInfo()
        {
            return _controller.GetUserInfo(_username);
        }

        public Task<IEnumerable<Track>> GetLovedTracks()
        {
            return _controller.GetLovedTracks(_username);
        }

        public Task<IEnumerable<Track>> GetRecentTracks()
        {
            return _controller.GetRecentTracks(_username);
        }

        public Task<IEnumerable<Album>> GetTopAlbums()
        {
            return _controller.GetTopAlbums(_username);
        }

        public Task<IEnumerable<Artist>> GetTopArtists()
        {
            return _controller.GetTopArtists(_username);
        }

        public Task<IEnumerable<Track>> GetTopTracks()
        {
            return _controller.GetTopTracks(_username);
        }
    }
}
