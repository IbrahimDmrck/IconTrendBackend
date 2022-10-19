using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaperFile : IEntity
    {
        public int FileId { get; set; }
        public int PaperId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Datetime { get; set; }
    }
}
