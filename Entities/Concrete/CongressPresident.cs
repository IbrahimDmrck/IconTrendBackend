using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CongressPresident:IEntity
    {
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string CongressPresidentName { get; set; }
    }
}
