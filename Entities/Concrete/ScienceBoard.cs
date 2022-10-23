using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ScienceBoard : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string ScienceBoardMemberName { get; set; }
        public string Univercity { get; set; }
    }
}
