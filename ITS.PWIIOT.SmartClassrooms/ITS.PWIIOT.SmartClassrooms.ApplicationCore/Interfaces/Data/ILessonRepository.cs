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
        Task<IEnumerable<Lesson>> GetLessons(DateTime start, DateTime end);
        Task<IEnumerable<Lesson>> GetLessonsByClassroom(DateTime start, DateTime? end, string classroomId);
        Task<IEnumerable<Lesson>> GetLessonsByCourse(DateTime start, DateTime? end, Guid courseId);
        Task<IEnumerable<Lesson>> GetLessonsByTeacher(DateTime start, DateTime? end, Guid teacherId);
        Task InsertLesson(Lesson lesson);
        Task UpdateLesson(Lesson lesson);
        Task DeleteLesson(Guid id);
    }
}
