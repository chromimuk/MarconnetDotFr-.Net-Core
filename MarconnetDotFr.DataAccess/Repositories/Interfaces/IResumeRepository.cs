using MarconnetDotFr.Core.Models;
using System.Collections.Generic;

namespace MarconnetDotFr.DataAccess.Repositories.Interfaces
{
    public interface IResumeRepository
    {
        IEnumerable<ResumeItemModel> GetWorkExperiences();

        IEnumerable<ResumeItemModel> GetUniversityDiplomas();

        IEnumerable<WorkItemModel> GetSideProjects();
    }
}