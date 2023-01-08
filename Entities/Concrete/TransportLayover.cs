using Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class TransportLayover : IEntity
    {
        [Key]
        public int TransportId { get; set; }
        public int Capacity { get; set; }
        public string MinDemand { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
       
    }
}
