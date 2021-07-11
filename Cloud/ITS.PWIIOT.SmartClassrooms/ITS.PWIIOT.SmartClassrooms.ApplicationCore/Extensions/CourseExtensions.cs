using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class CourseExtensions
    {
        public static IEnumerable<CourseInfo> ToCourseInfo(this IEnumerable<Course> courses)
        {
            return courses.Select(c => c.ToCourseInfo());
        }

        public static CourseInfo ToCourseInfo(this Course course)
        {
            return new CourseInfo
            {
                Id = course.Id,
                Name = course.Name,
            };
        }
    }
}
