using LastFM.AspNetCore.Stats;
using LastFM.AspNetCore.Stats.Entities;
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

        public Task<IEnumerable<Track>> GetLovedTracks(string username)
        {
            return _controller.GetLovedTracks(username);
        }

        public Task<IEnumerable<Track>> GetRecentTracks(string username)
        {
            return _controller.GetRecentTracks(username);
        }

        public Task<IEnumerable<Album>> GetTopAlbums(string username)
        {
            return _controller.GetTopAlbums(username);
        }

        public Task<IEnumerable<Artist>> GetTopArtists(string username)
        {
            return _controller.GetTopArtists(username);
        }

        public Task<IEnumerable<Track>> GetTopTracks(string username)
        {
            return _controller.GetTopTracks(username);
        }
    }
}
