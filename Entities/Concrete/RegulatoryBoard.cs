using Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class RegulatoryBoard:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CongressId { get; set; }
        public string RegulatoryBoardMemberName { get; set; }
        public string Univercity { get; set; }
    }
}
