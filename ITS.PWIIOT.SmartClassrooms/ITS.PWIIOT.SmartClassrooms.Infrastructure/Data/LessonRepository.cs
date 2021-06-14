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

        public async Task DeleteLesson(Guid id)
        {
            var product = new Lesson
            {
                Id = id
            };
            _smartClassesContext.Entry(product).State = EntityState.Deleted;
           await  _smartClassesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessons(DateTime start, DateTime end)
        {
            var lessons = await _smartClassesContext.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Teacher)
                .Include(l => l.Subject)
                .Where(l => l.StartDate >= start)
                .ToListAsync();

            return lessons;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByClassroom(DateTime start, DateTime? end, string classroomId)
        {
            var lessons = await _smartClassesContext.Lessons
                .Include(l => l.Classroom)
                    .ThenInclude(c => c.Building)
                .Include(l => l.Teacher)
                .Include(l => l.Subject)
                .Where(l => l.StartDate >= start && l.Classroom.GetClassroomId() == classroomId)
                .ToListAsync();

            return lessons;
        }

        public async Task InsertLesson(Lesson lesson)
        {
            _smartClassesContext.Add(lesson);
            await _smartClassesContext.SaveChangesAsync();
        }

        public async Task UpdateLesson(Lesson lesson)
        {
            _smartClassesContext.Entry(lesson).State = EntityState.Modified;
            await _smartClassesContext.SaveChangesAsync();
        }
    }

}
