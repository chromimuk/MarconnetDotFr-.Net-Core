using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.DAO.Interfaces;

namespace MarconnetDotFr.DataAccess.Mappers
{
    public static class ResumeMapper
    {
        public static ResumeItemModel ToResumeItemModel(IResumeItemModelDAO dao)
        {
            return new ResumeItemModel()
            {
                Image = dao.GetImage(),
                Title = dao.GetTitle(),
                ShortTitle = dao.GetShortTitle(),
                Location = dao.GetLocation(),
                ShortLocation = dao.GetShortLocation(),
                Description = dao.GetDescription(),
                Tech = dao.GetTech()
            };
        }

        public static WorkItemModel ToWorkItemModel(IWorkItemModelDAO dao)
        {
            return new WorkItemModel()
            {
                Title = dao.GetTitle(),
                Alias = dao.GetAlias(),
                Description = dao.GetDescription(),
                Link = dao.GetLink(),
                Subtitle = dao.GetSubtitle()
            };
        }

        public static WorkModel ToWorkModel(IWorkModelDAO dao)
        {
            return new WorkModel()
            {
                Title = dao.GetTitle(),
                Link = dao.GetLink(),
                Subtitle = dao.GetSubtitle(),
                Image = dao.GetImage(),
                Period = dao.GetPeriod(),
                Content = dao.GetContent(),
                Screenshots = dao.GetScreenshots(),
            };
        }
    }
}