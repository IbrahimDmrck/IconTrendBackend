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
        //public string Accepted { get; set; }
        //public string Student { get; set; }
        //public string Type { get; set; }
        //public int ContactId { get; set; }
        //public string AltContact { get; set; }
        //public DateTime LastUpdate { get; set; }
        //public string Consent { get; set; }
        //public string Format { get; set; }
        //public string  Keywords { get; set; }
        //public string Comment { get; set; }
        //public string Abstract { get; set; }
        //public int EditTime { get; set; }
       // public string PcNotes { get; set; }
       // public string EditToken { get; set; }
       // public string Password { get; set; }
    }
}
