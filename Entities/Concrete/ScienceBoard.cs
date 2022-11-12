using Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class ScienceBoard : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string ScienceBoardMemberName { get; set; }
        public string Univercity { get; set; }
    }
}
