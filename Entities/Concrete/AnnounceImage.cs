using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AnnounceImage:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int AnnounceId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
