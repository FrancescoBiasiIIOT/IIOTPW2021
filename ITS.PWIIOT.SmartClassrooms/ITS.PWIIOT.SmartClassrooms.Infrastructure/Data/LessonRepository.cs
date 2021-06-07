using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Infrastructure.Data
{
    public class LessonRepository : ILessonRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public LessonRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public void DeleteLesson(Guid id)
        {
            var product = new Lesson
            {
                Id = id
            };
            _smartClassesContext.Entry(product).State = EntityState.Deleted;
            _smartClassesContext.SaveChanges();
        }

        public IEnumerable<Lesson> GetLessons(DateTime start, DateTime end)
        {
            var lessons = _smartClassesContext.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Teacher)
                .Include(l => l.Subject)
                .Where(l => l.StartDate >= start && l.GetEndDate(l.Duration) <= end)
                .ToList();

            return lessons;
        }

        public IEnumerable<Lesson> GetLessonsByClassroom(DateTime start, DateTime end, Guid classroomId)
        {
            var lessons = _smartClassesContext.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Teacher)
                .Include(l => l.Subject)
                .Where(l => l.StartDate >= start && l.GetEndDate(l.Duration) <= end
                    && l.Classroom.Id == classroomId)
                .ToList();

            return lessons;
        }

        public void InsertLesson(Lesson lesson)
        {
            _smartClassesContext.Add(lesson);
            _smartClassesContext.SaveChanges();
        }

        public void UpdateLesson(Lesson lesson)
        {
            _smartClassesContext.Entry(lesson).State = EntityState.Modified;
            _smartClassesContext.SaveChanges();
        }
    }

}
