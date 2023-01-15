namespace MarconnetDotFr.Core.Models.FootyStats
{
    public class GameResult
    {
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public Team TeamA { get; }
        public Team TeamB { get; }

        public GameResult(Team teamA, Team teamB, int teamAScore, int teamBScore)
        {
            TeamA = teamA;
            TeamB = teamB;
            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
        }
    }
}