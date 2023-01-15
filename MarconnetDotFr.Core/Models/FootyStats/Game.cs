using System;

namespace MarconnetDotFr.Core.Models.FootyStats
{
    public class Game
    {
        public DateTime? Date { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public GameResult Result { get; set; }
    }
}