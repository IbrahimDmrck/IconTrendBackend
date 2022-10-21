using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmailQueue : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Queued { get; set; }
        public DateTime Sent { get; set; }
        public int Tries { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ReferenceId { get; set; }
    }
}
