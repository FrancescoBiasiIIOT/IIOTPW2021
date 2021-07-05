using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.DTO
{
    public class UserInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsCorrect { get; set; }
        public Guid CourseId { get; set; }
        public Guid TeacherId { get; set; }
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Administrator = 0,
        Teacher = 1,
        Studente = 2
    }
}
