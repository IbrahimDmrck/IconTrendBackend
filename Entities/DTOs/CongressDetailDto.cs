using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CongressDetailDto
    {
        public int CongressId { get; set; }
        public string CongressName { get; set; }
        public int CongressPresidentId { get; set; }
        public string CogressPresidentName { get; set; }
        public string CongressPoster { get; set; }
        public string CongressAbout { get; set; }
        public string CongressCity { get; set; }
        public string CongressPlace { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }
        public List<Topic> Topics { get; set; }
        public List<RegulatoryBoard> RegulatoryBoards { get; set; }
        public List<ScienceBoard> ScienceBoards { get; set; }
        public List<CongressImage> CongressImages { get; set; }
    }
}
