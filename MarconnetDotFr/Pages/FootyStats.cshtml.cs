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
        private IList<AttendanceItemModel> _attendances;

        public FootyStatsModel(IConfiguration configuration, IFootyRepository footyRepository)
        {
            _configuration = configuration;
            _footyRepository = footyRepository;
        }

        public void OnGet()
        {
        }

        public JsonResult OnPostRead()
        {
            _attendances = _footyRepository.GetAttendances("fcsm").Reverse().ToList();
            
            _attendances.Single(x => x.season == "2001/2002").notes = "Nouveau Bonal";

            foreach (var attendance in _attendances)
            {
                attendance.ranking = 21 - attendance.ranking;

                if (attendance.division == "D1")
                {
                    attendance.ranking += 20;
                }
            }

            return new JsonResult(_attendances);
        }
    }
}
