using System;

namespace MarconnetDotFr.DataAccess.DAO.Interfaces
{
    public interface IWorldCupGameDao
    {
        DateTime GetDate();
        string GetTeamA();
        string GetTeamB();
        string GetScore();
        string GetGroup();
        int GetTeamAResults();
        int GetTeamBResults();
        int GetDrawResults();

    }
}
