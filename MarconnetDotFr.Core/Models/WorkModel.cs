using System.Collections.Generic;

namespace MarconnetDotFr.Core.Models
{
    public class WorkModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        public string Period { get; set; }
        public string Content { get; set; }
        public IList<string> Screenshots { get; set; }
    }
}