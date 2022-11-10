using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AnnouncementDetailDto:IDto
    {
        public int Id { get; set; }
        public string AnnounceTitle { get; set; }
        public string AnnounceContent { get; set; }
        public bool AnnounceStatus { get; set; }
        public DateTime AnnounceDate { get; set; }
        public List<AnnounceImage> AnnounceImages { get; set; }
    }
}
