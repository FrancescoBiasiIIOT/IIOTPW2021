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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public TeacherRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public async Task<Subject> GetSubjectById(Guid id)
        {
            return await _smartClassesContext.
            Subjects.Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var teachers = await _smartClassesContext.Teachers
                .Include(t => t.Teaches)
                .ToListAsync();

            return teachers;
        }

        public async Task<Teacher> GetTeacherById(Guid id)
        {
            return await _smartClassesContext.
                Teachers.Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _smartClassesContext.Subjects.ToListAsync();
        }
    }
}
