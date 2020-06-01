using System.Collections.Generic;

namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IWorkModelDAO
    {
        string GetTitle();

        string GetLink();

        string GetSubtitle();

        string GetImage();

        string GetPeriod();

        string GetContent();

        List<string> GetScreenshots();
    }
}