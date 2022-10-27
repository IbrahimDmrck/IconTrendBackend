using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Models
{
    public class TransportLayover 
    {
       
        public int TransportId { get; set; }
        public int Capacity { get; set; }
        public string MinDemand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
