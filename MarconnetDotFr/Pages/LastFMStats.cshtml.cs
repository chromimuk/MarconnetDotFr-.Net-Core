using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LastFM.AspNetCore.Stats.Entities;
using MarconnetDotFr.Core.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarconnetDotFr.Pages
{
    public class LastFMStatsModel : PageModel
    {
        private readonly ILastFMStatsService _lastFMStatsService;

        public LastFMUser LastFMUser { get; set; }
        public Task<IEnumerable<Album>> TopAlbums { get; set; }
        public Task<IEnumerable<Track>> TopTracks { get; set; }
        public Task<IEnumerable<Artist>> TopArtists { get; set; }
        public Task<IEnumerable<Track>> RecentTracks { get; set; }
        public string ErrorMessage { get; set; }

        public LastFMStatsModel(ILastFMStatsService lastFMStatsService)
        {
            _lastFMStatsService = lastFMStatsService;
        }

        public void OnGet(string username = "chromimuk")
        {
            var a = _lastFMStatsService.GetTopAlbums(username, 9).Result;

            try
            {
                LastFMUser = _lastFMStatsService.GetUserInfo(username).Result;
            }
            catch(Exception e)
            {
                ErrorMessage = $"Could not connect to LastFM API ({e.Message})";
                return;
            }



            TopAlbums = _lastFMStatsService.GetTopAlbums(username, 9);
            TopTracks = _lastFMStatsService.GetTopTracks(username, 9);
            TopArtists = _lastFMStatsService.GetTopArtists(username, 9);
            RecentTracks = _lastFMStatsService.GetRecentTracks(username, 9);
        }
    }
}