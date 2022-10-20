using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool status { get; set; }
        public string Departman { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostaCode { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string Orcid { get; set; }
        public string Url { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public int Position { get; set; }
        public string PositionTitle { get; set; }
        public string Organization { get; set; }

    }
}
