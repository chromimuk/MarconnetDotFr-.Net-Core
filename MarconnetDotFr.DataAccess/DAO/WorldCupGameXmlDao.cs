using MarconnetDotFr.DataAccess.DAO.Interfaces;
using System;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.DAO
{
    public class WorldCupGameXmlDao : XmlDao, IWorldCupGameDao
    {
        public WorldCupGameXmlDao(XElement e) : base(e)
        {
        }

        public DateTime GetDate()
        {
            return GetDateTimeValue("date");
        }

        public int GetDrawResults()
        {
            return GetIntValue("drawResult");
        }

        public string GetGroup()
        {
            return GetStringValue("group");
        }

        public string GetScore()
        {
            return GetStringValue("score");
        }

        public string GetTeamA()
        {
            return GetStringValue("teamA");
        }

        public int GetTeamAResults()
        {
            return GetIntValue("teamAResult");
        }

        public string GetTeamB()
        {
            return GetStringValue("teamB");
        }

        public int GetTeamBResults()
        {
            return GetIntValue("teamBResult");
        }
    }
}
