using Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class Topic : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string TopicName { get; set; }
        public string Category { get; set; }
    }
}
