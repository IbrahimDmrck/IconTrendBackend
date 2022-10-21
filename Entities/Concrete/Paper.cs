using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Paper : IEntity
    {
        public int PaperId { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool PaperStatus { get; set; }

    }
}
