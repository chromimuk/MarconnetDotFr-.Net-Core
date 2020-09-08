using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MarconnetDotFr.Pages
{
    public class WorkExampleModel : PageModel
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IWorkRepository _workRepository;

        public WorkModel WorkModel { get; set; }

        public WorkExampleModel(IResumeRepository resumeRepository, IWorkRepository workRepository)
        {
            _resumeRepository = resumeRepository;
            _workRepository = workRepository;
        }

        public IActionResult OnGet(string title)
        {
            IEnumerable<WorkItemModel> workItems = _resumeRepository.GetPersonalWork();
            IEnumerable<string> _availableWorks = workItems.Select(x => x.Alias);

            if (title == "idkcss")
            {
                return RedirectToPage("IdkCss");
            }
            else if (_availableWorks.Contains(title))
            {
                WorkModel = _workRepository.GetWorkModel(title);
                if (WorkModel != null)
                {
                    return Page();
                }
                else
                    return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}