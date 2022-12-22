using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class KongreDetailDto:IDto
    {
        public int KongreId { get; set; }
        public string KongreBaskani { get; set; }
        public string KongreDuzenlemeKurulu { get; set; }
        public string BilimKurulu { get; set; }
        public string KongreKonusu { get; set; }
        public string KongreAdi { get; set; }
        public string KongreHakkinda { get; set; }
        public string KongreAdresi { get; set; }
        public DateTime KongreTarihi { get; set; }
        public List<KongreImage> KongreImages { get; set; }
    }
}
