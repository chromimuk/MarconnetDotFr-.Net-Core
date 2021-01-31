namespace MarconnetDotFr.Core.Models
{
    public class SeasonItemModel
    {
        public string season { get; set; }
        public string division { get; set; }
        public int? attendance { get; set; }
        public int? ranking { get; set; }
        public int? rankingForChart
        {
            get
            {
                var rank = 21 - ranking;

                if (division == "D1" || division == "D1-N" || division == "D1-B")
                {
                    rank += 20;
                }

                return rank;
            }
        }
        public string coupedefrance { get; set; }
        public string coupedelaligue { get; set; }
        public string europe { get; set; }
        public string notes { get; set; }
    }
}