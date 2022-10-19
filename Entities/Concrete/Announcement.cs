using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Announcement:IEntity
    {
        public int Id { get; set; }
        public int PopUpStatus { get; set; }
        public string PopUpContent { get; set; }
        public string PopUpContenEnglish { get; set; }
        public DateTime ImportantDate { get; set; }
    }
}
