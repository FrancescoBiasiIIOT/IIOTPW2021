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

        public IEnumerable<Teacher> GetTeachers()
        {
            var teachers = _smartClassesContext.Teachers
                .Include(t => t.Subjects)
                .ToList();

            return teachers;
        }
    }
}
