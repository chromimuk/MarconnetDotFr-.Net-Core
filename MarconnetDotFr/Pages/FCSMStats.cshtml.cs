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
    public class FCSMStatsModel : PageModel
    {

        private readonly IConfiguration _configuration;
        private readonly IFootyRepository _footyRepository;
        private IList<SeasonModel> seasons;

        public int NbSeason { get; set; }
        public int NbSeasonInTopLeague { get; set; }
        public int NbLeagueTitleWon { get; set; }
        public int NbCupWon { get; set; }
        public int NbEuropeanTitleWon { get; set; }

        public FCSMStatsModel(IConfiguration configuration, IFootyRepository footyRepository)
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

            NbSeason = seasons.Count();
            NbSeasonInTopLeague = seasons.Count(x => x.division == Division.D1);
            NbLeagueTitleWon = seasons.Count(x => x.ranking == 1);
            NbCupWon = seasons.Count(x => x.coupedefrance == CupPerformance.Winner) + seasons.Count(x => x.coupedelaligue == CupPerformance.Winner);
            NbEuropeanTitleWon = seasons.Count(x => x.europe == "Vainqueur");
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

        public JsonResult OnPostReadCoupeDeLaLigue()
        {
            if (seasons == null)
            {
                seasons = _footyRepository.GetSeasons("fcsm").Reverse().ToList();
            }

            SeasonModel firstSeasonWithCdL = seasons.Single(x => x.season == "1994/1995"); // CdL created in 1994/1995
            IEnumerable<SeasonModel> results = seasons.Skip(seasons.ToList().FindIndex(x => x == firstSeasonWithCdL));

            return new JsonResult(results);
        }

        public JsonResult OnPostReadDivision()
        {
            if (seasons == null)
            {
                seasons = _footyRepository.GetSeasons("fcsm").Reverse().ToList();
            }

            IList<DivisionCountModel> divisionCount = new List<DivisionCountModel>();
            divisionCount.Add(item: new DivisionCountModel() { division = Division.D1, count = seasons.Count(x => x.division == Division.D1) });
            divisionCount.Add(item: new DivisionCountModel() { division = Division.D2, count = seasons.Count(x => x.division == Division.D2) });
            divisionCount.Add(item: new DivisionCountModel() { division = Division.D3, count = seasons.Count(x => x.division == Division.D3) });

            return new JsonResult(divisionCount);
        }
    }
}
