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
        public IEnumerable<WorkItemModel> HighlightedSideProjects { get; set; }
        public IEnumerable<IGrouping<string, WorkItemModel>> SideProjects { get; set; }

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

            IEnumerable<WorkItemModel> sideProjects = _resumeRepository.GetSideProjects();
            HighlightedSideProjects = sideProjects.Where(x => x.IsHighlighted);
            SideProjects = sideProjects.Where(x => !x.IsHighlighted).GroupBy(x => x.Subtitle);
        }
    }
}