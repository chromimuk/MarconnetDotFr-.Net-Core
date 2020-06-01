using MarconnetDotFr.Core.Models;

namespace MarconnetDotFr.DataAccess.Repositories.Interfaces
{
    public interface IWorkRepository
    {
        WorkModel GetWorkModel(string workModelName);
    }
}