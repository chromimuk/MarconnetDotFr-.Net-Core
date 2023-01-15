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
    public class MPPWorldCup2022Model : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IFootyRepository _footyRepository;

        public MPPWorldCup2022Model(IConfiguration configuration, IFootyRepository footyRepository)
        {
            _configuration = configuration;
            _footyRepository = footyRepository;
        }
        
        public void OnGet()
        {
            var a = _footyRepository.GetWorldCupGames().ToList();
        }
    }
}
