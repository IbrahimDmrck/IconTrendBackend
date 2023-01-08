using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BankAccountInfo:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string BankCode { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
