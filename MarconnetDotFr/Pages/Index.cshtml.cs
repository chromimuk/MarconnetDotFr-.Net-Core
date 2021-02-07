using MarconnetDotFr.Core.Helpers;
using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MarconnetDotFr.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IResumeRepository _resumeRepository;

        public int CurrentAge { get; set; }
        public IEnumerable<ResumeItemModel> WorkExperiences { get; set; }
        public IEnumerable<ResumeItemModel> UniversityDiplomas { get; set; }
        public IEnumerable<IGrouping<string, WorkItemModel>> PersonalWork { get; set; }

        public IndexModel(IConfiguration configuration, IResumeRepository resumeRepository)
        {
            _configuration = configuration;
            _resumeRepository = resumeRepository;
        }

        public void OnGet()
        {
            CurrentAge = DateHelper.GetYearDifference(DateTime.UtcNow, DateTime.Parse(_configuration["BirthdayDate"]));
            WorkExperiences = _resumeRepository.GetWorkExperiences();
            UniversityDiplomas = _resumeRepository.GetUniversityDiplomas();
            PersonalWork = _resumeRepository.GetPersonalWork().GroupBy(x => x.Subtitle);
        }
    }
}