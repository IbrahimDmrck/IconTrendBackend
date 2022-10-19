using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Withdrawn : IEntity
    {
        public int PaperId { get; set; }
        public string Title { get; set; }
        public string ContactAuthor { get; set; }
        public string  ContactEmail { get; set; }
        public string PaperSql { get; set; }
        public string AuthorSql { get; set; }
        public string TopicSql { get; set; }
        public DateTime WithdrawnDate { get; set; }
        public List<string> withdrawnBy { get; set; }
    }
}
