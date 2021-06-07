using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data
{
    public interface ILessonRepository
    {
        public IEnumerable<Lesson> GetLessons(DateTime start, DateTime end);
        public IEnumerable<Lesson> GetLessonsByClassroom(DateTime start, DateTime end, Guid classroomId);
        public void InsertLesson(Lesson lesson);
        public void UpdateLesson(Lesson lesson);
        public void DeleteLesson(Guid id);
    }
}
