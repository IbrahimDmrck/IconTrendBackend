﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Topic : IEntity
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string Short { get; set; }
    }
}
