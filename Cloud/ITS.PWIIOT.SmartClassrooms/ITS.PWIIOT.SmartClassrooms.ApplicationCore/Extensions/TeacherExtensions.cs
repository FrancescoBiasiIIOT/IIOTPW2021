using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class TeacherExtensions
    {
        public static IEnumerable<TeacherInfo> ToTeachersInfo(this IEnumerable<Teacher> teachers)
        {
            return teachers.Select(t => t.ToTeacherInfo());
        }

        public static TeacherInfo ToTeacherInfo(this Teacher teacher)
        {
            return new TeacherInfo
            {
                Id = teacher.Id,
                FullName = teacher.GetFullName()
            };
        }
    }
}
