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

        public async Task<Classrooms> GetClassroomById(string id)
        {
            return await _context.Classrooms
                .Include(c => c.Building)
                .Where(c => c.GetClassroomId() == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Classrooms>> GetClassrooms()
        {
            return await _context.Classrooms
                .Include(c => c.Building)
                .ToListAsync();
        }
    }
}
