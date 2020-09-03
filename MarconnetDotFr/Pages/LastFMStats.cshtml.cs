using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastFM.AspNetCore.Stats.Entities;
using MarconnetDotFr.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace MarconnetDotFr.Pages
{
    public class LastFMStatsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILastFMStatsService _lastFMStatsService;

        public Task<LastFMUser> LastFMUser { get; set; }
        public Task<IEnumerable<Album>> TopAlbums { get; set; }
        public Task<IEnumerable<Track>> TopTracks { get; set; }
        public Task<IEnumerable<Track>> RecentTracks { get; set; }

        public LastFMStatsModel(IConfiguration configuration, ILastFMStatsService lastFMStatsService)
        {
            _configuration = configuration;
            _lastFMStatsService = lastFMStatsService;
        }

        public void OnGet()
        {
            LastFMUser = _lastFMStatsService.GetUserInfo();
            TopAlbums = _lastFMStatsService.GetTopAlbums();
            TopTracks = _lastFMStatsService.GetTopTracks();
            RecentTracks = _lastFMStatsService.GetRecentTracks();
        }
    }
}