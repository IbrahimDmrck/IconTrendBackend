using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Models
{
    public class Announcement 
    {
    
        public int Id { get; set; }
        public string AnnounceTitle { get; set; }
        public string AnnounceContent { get; set; }
        public bool AnnounceStatus { get; set; }
        public DateTime AnnounceDate { get; set; }
    }
}
