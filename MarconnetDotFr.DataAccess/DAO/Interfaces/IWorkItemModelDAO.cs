namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IWorkItemModelDao
    {
        string GetTitle();

        string GetAlias();

        string GetLink();

        string GetSubtitle();

        string GetDescription();
    }
}