namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IResumeItemModelDAO
    {
        string GetImage();

        string GetTitle();

        string GetShortTitle();

        string GetLocation();

        string GetShortLocation();

        string GetDescription();

        string GetTech();
    }
}