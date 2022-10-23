﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Congress : IEntity
    {
        [Key]
        public int CongressId { get; set; }
        public int CongressPresidentId { get; set; }
        public string CongressName { get; set; }
        public string CongressAbout { get; set; }
        public string CongressCity { get; set; }
        public string CongressPlace { get; set; }
        public DateTime CongressDate { get; set; }
        public bool CongressStatus { get; set; }
    }
}
