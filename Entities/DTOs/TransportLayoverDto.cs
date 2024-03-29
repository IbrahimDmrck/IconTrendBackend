﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TransportLayoverDetailDto:IDto
    {
        public int TransportId { get; set; }
        public int Capacity { get; set; }
        public string MinDemand { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public List<TransportLayoverImage> TransportLayoverImages { get; set; }
    }
}
