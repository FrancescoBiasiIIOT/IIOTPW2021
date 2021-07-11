using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Course_services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseInfo> GetCourseById(Guid id)
        {
            var course = await _courseRepository.GetCourseById(id);
            return course.ToCourseInfo();
        }

        public async Task<IEnumerable<CourseInfo>> GetCourses()
        {
            var courses = await _courseRepository.GetCourses();
            return courses.ToCourseInfo();
        }
    }
}
