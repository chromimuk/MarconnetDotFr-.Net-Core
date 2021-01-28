namespace MarconnetDotFr.Core.Models
{
    public class AttendanceItemModel
    {
        public string season { get; set; }
        public string division { get; set; }
        public int? attendance { get; set; }
        public int? ranking { get; set; }
        public string coupedefrance { get; set; }
        public string coupedelaligue { get; set; }
        public string europe { get; set; }
        public string notes { get; set; }
    }
}