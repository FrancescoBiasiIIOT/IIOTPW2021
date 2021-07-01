using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Classroom_services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IBuildingRepository _buildingRepository;

        public ClassroomService(IClassroomRepository classroomRepository, IBuildingRepository buildingRepository)
        {
            _classroomRepository = classroomRepository;
            _buildingRepository = buildingRepository;
        }

        public async Task<IEnumerable<Domain.Building>> GetBuildings()
        {
            var buildings = await _buildingRepository.GetBuildings();
            return buildings;
        }

        public async Task<ClassroomInfo> GetClassroomById(string classroomId)
        {
            var classroom = await _classroomRepository.GetClassroomById(classroomId);
            return classroom.ToClassroomInfo();
        }

        public async Task<IEnumerable<ClassroomInfo>> GetClassrooms()
        {
            var classrooms = await _classroomRepository.GetClassrooms();
            return classrooms.ToClassroomInfo();
        }

        public async Task SetClassroomAvailable(string classroomId)
        {
            var classroom = await _classroomRepository.GetClassroomById(classroomId);
            if(classroom != null)
            {
                classroom.SetAvailable();
                await _classroomRepository.UpdateClassroom(classroom);
            }
        }
    }
}
