using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CongressDetailDto:IDto
    {
        public int CongressId { get; set; }
        public string CongressPresidentName { get; set; }
        public string RegulatoryBoard { get; set; }
        public string ScienceBoard { get; set; }
        public string Topic { get; set; }
        public string Univercity { get; set; }
        public string CongressName { get; set; }
        public string CongressAbout { get; set; }
        public string CongressAdress { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }
        public List<CongressImage> CongressImages { get; set; }
    }
}
