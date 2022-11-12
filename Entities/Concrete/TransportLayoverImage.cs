using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TransportLayoverImage:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int TransportLayoverId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
