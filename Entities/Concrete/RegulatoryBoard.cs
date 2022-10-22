using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RegulatoryBoard:IEntity
    {
        public int Id { get; set; }
        public string RegulatoryBoardMemberName { get; set; }
        public string Univercity { get; set; }
    }
}
