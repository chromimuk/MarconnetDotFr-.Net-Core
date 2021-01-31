using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarconnetDotFr.Pages
{
    public class FootyStatsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IFootyRepository _footyRepository;
        private IList<SeasonItemModel> seasons;

        public FootyStatsModel(IConfiguration configuration, IFootyRepository footyRepository)
        {
            _configuration = configuration;
            _footyRepository = footyRepository;
        }

        public void OnGet()
        {
            // nothing special to do
        }

        public JsonResult OnPostRead()
        {
            if (seasons == null)
            {
                seasons = _footyRepository.GetSeasons("fcsm").Reverse().ToList();
            }

            // add notes
            seasons.Single(x => x.season == "2001/2002").notes = "Nouveau Bonal";

            return new JsonResult(seasons);
        }
    }
}
