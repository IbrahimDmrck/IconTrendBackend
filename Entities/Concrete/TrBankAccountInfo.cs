using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TrBankAccountInfo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Iban { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
