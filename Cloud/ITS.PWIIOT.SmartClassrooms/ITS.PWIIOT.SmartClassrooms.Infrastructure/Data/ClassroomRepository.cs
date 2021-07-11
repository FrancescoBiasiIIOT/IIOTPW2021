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
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SmartClassesContext _context;

        public ClassroomRepository(SmartClassesContext context)
        {
            _context = context;
        }

        public async Task<Classroom> GetById(Guid id)
        {
            return await _context.Classrooms
           .Include(c => c.Building)
           .Where(c => c.Id == id)
           .FirstOrDefaultAsync();
        }

        public async Task<Classroom> GetClassroomById(string id)
        {
            var classrooms =  await _context.Classrooms
                .Include(c => c.Building)
                .ToListAsync();
            return classrooms.FirstOrDefault(c => c.GetClassroomId() == id);
        }

        public async Task<IEnumerable<Classroom>> GetClassrooms()
        {
            return await _context.Classrooms
                .Include(c => c.Building)
                .ToListAsync();
        }

        public async Task UpdateClassroom(Classroom classroom)
        {
            _context.Entry(classroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
