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
        public int CongressPresidentId { get; set; }
        public string CongressPresidentName { get; set; }
    }
}
