using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Teacher_services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherInfo> GetTeacherById(Guid id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);
            return teacher.ToTeacherInfo();
        }

        public async Task<IEnumerable<TeacherInfo>> GetTeachers()
        {
            var teachers = await _teacherRepository.GetTeachers();
            return teachers.ToTeachersInfo();
        }
    }
}
