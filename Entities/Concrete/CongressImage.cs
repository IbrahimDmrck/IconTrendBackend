using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class CongressImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
