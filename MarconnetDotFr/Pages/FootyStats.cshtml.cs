using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.Core.Models;
using MarconnetDotFr.Core.Models.FootyStats;
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
        private IList<SeasonModel> seasons;

        public int NbLeagueTitleWon { get; set; }
        public int NbCupWon { get; set; }
        public int NbEuropeanTitleWon { get; set; }

        public FootyStatsModel(IConfiguration configuration, IFootyRepository footyRepository)
        {
            _configuration = configuration;
            _footyRepository = footyRepository;
        }

        public void OnGet()
        {
            if (seasons == null)
            {
                seasons = _footyRepository.GetSeasons("fcsm").Reverse().ToList();
            }

            NbLeagueTitleWon = seasons.Where(x => x.ranking == 1).Count();
            NbCupWon = seasons.Where(x => x.coupedefrance == CupPerformance.Winner).Count() + seasons.Where(x => x.coupedelaligue == CupPerformance.Winner).Count();
            NbEuropeanTitleWon = seasons.Where(x => x.europe == "Vainqueur").Count();
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

        public JsonResult OnPostReadDivision()
        {
            if (seasons == null)
            {
                seasons = _footyRepository.GetSeasons("fcsm").Reverse().ToList();
            }

            IList<DivisionCountModel> divisionCount = new List<DivisionCountModel>();
            divisionCount.Add(item: new DivisionCountModel() { division = Division.D1, count = seasons.Where(x => x.division == Division.D1).Count() });
            divisionCount.Add(item: new DivisionCountModel() { division = Division.D2, count = seasons.Where(x => x.division == Division.D2).Count() });

            return new JsonResult(divisionCount);
        }
    }
}
