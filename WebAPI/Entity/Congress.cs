using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entity
{
    public class Congress
    {
        public int CongressId { get; set; }
        public int CongressPresidentId { get; set; }
        public string CongressName { get; set; }
        public string CongressAbout { get; set; }
        public string CongressCity { get; set; }
        public string CongressPlace { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }

    }
}
