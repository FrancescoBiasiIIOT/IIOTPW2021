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
    public class CourseRepository : ICourseRepository
    {
        private readonly SmartClassesContext smartClassesContext;

        public CourseRepository(SmartClassesContext smartClassesContext)
        {
            this.smartClassesContext = smartClassesContext;
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await smartClassesContext.Courses.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await smartClassesContext.Courses.ToListAsync();
        }
    }
}
