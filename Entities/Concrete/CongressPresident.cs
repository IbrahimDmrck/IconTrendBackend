using Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class CongressPresident:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string CongressPresidentName { get; set; }
    }
}
