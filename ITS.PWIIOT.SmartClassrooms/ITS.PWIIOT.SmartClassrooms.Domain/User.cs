using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Users")]
    public class User : EntityBase<int>
    {
        public string Username { get; set; }
        public string  Password { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

    }

    public enum Roles
    {
        Administrator = 0,
        Teacher = 1,
        Studente = 2
    }
}
