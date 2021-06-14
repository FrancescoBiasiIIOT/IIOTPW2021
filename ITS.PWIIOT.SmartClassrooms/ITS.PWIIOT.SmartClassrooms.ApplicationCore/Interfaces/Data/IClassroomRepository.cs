using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data
{
    public interface IClassroomRepository
    {
        Task<Classroom> GetClassroomById(string id);
        Task<Classroom> GetById(Guid id);
        Task<IEnumerable<Classroom>> GetClassrooms();
        Task UpdateClassroom(Classroom classroom);
    }
}
