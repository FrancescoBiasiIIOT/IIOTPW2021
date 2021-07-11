using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class ClassroomExtensions
    {
        public static IEnumerable<ClassroomInfo> ToClassroomInfo(this IEnumerable<Domain.Classroom> classroom)
        {
            return classroom.Select(c => c.ToClassroomInfo());
        }
        public static ClassroomInfo ToClassroomInfo(this Domain.Classroom classroom)
        {
            return new ClassroomInfo
            {
                Id = classroom.Id,
                Name = classroom.GetClassroomId()
            };
        }
    }
}
