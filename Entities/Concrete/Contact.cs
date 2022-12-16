using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
