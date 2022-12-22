using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities.Concrete
{
    public class Congress : IEntity
    {
        [Key]
        public int CongressId { get; set; }
        public string CongressPresidentName { get; set; }
        public string RegulatoryBoard { get; set; }
        public string ScienceBoard { get; set; }
        public string Topic { get; set; }
        public string Univercity { get; set; }
        public string CongressName { get; set; }
        public string CongressAbout { get; set; }
        public string CongressAdress { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }
    }
}
