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
        Task<Classrooms> GetClassroomById(Guid id);
        Task<IEnumerable<Classrooms>> GetClassrooms();
    }
}
