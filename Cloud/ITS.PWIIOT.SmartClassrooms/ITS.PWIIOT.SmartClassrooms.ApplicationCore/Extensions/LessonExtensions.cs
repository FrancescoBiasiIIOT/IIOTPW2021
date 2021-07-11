using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class LessonExtensions
    {
        public static Lesson ToLesson(this LessonInfo lesson)
        {
            return new Lesson
            {
                StartDate = lesson.StartDate,
                EndDate = (DateTime)lesson.EndDate,
            };
        }
        public static LessonInfo ToLessonInfo(this Lesson lesson)
        {
            return new LessonInfo
            {
                StartDate = lesson.StartDate,
                EndDate = lesson.EndDate,
                ClassroomId = lesson.Classroom.GetClassroomId(),
                CourseId = lesson.CourseId,
                SubjectId = lesson.SubjectId,
                TeacherId = lesson.TeacherId

            };
        }
    }
}
