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
    public class MicrocontrollerRepository : IMicrocontrollerRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public MicrocontrollerRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public async Task<Microcontroller> GetDeviceByClassroomId(string id)
        {
            var classrooms = await _smartClassesContext.Microcontrollers
                .Include(m => m.Classroom)
                    .ThenInclude(c => c.Building)
                .Include(m => m.Gateway)
                .ToListAsync();
            var classroom = classrooms.Where(c => c.Classroom.GetClassroomId() == id)
                .FirstOrDefault();

            return classroom;

        }
    }
}
