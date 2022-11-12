using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class Announcement:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string AnnounceTitle { get; set; }
        public string AnnounceContent { get; set; }
        public bool AnnounceStatus { get; set; }
        public DateTime AnnounceDate { get; set; }
    }
}
