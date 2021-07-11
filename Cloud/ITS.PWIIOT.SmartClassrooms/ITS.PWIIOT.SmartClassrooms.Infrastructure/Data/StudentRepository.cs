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
    public class StudentRepository : IStudentRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public StudentRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await _smartClassesContext.Students
                .Include(s => s.Course)
.Where(t => t.Email == email)
.FirstOrDefaultAsync();
        }
    }
}
