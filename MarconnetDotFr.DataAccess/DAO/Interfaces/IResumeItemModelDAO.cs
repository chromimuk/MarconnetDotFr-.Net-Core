namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IResumeItemModelDao
    {
        string GetImage();

        string GetTitle();

        string GetShortTitle();

        string GetLocation();

        string GetShortLocation();

        string GetDescription();

        string GetTech();

        string GetNote();
    }
}