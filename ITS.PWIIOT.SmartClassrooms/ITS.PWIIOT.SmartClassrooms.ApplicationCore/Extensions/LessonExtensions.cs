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
                Duration = lesson.GetDuration(),
            };
        }
    }
}
