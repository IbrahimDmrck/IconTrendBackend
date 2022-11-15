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
        public string CongressName { get; set; }
        public int CongressPresidentId { get; set; }
        public string CongressPresidentName { get; set; }
        public string CongressAbout { get; set; }
        public string CongressCity { get; set; }
        public string CongressPlace { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ScienceBoardId { get; set; }
        public string ScienceBoardMemberName { get; set; }
        public string ScienceBoardMemberUnivercity { get; set; }
        public int RegulatoryBoardId { get; set; }
        public string RegulatoryBoardMemberName { get; set; }
        public string RegulatoryBoardMemberUnivercity { get; set; }
        public List<CongressImage> CongressImages { get; set; }
    }
}
