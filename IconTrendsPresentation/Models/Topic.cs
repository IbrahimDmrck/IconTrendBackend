using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Models
{
    public class Topic 
    {
       
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string TopicName { get; set; }
        public string Category { get; set; }
    }
}
