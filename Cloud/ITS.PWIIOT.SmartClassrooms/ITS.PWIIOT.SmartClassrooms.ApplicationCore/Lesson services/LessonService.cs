using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.IOT_Hub_services;
using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Lesson_services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IIotHubService _iotHubService;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMicrocontrollerRepository _microcontrollerRepository;
        public LessonService(ILessonRepository lessonService, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, IClassroomRepository classroomRepository, ICourseRepository courseRepository, IIotHubService iotHubService, IMicrocontrollerRepository microcontrollerRepository)
        {
            _lessonRepository = lessonService;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _classroomRepository = classroomRepository;
            _courseRepository = courseRepository;
            _iotHubService = iotHubService;
            _microcontrollerRepository = microcontrollerRepository;
        }

        public async Task AddNewLesson(LessonInfo lessonInfo)
        {
            var lesson = lessonInfo.ToLesson();
            lesson.Course = await _courseRepository.GetCourseById(lessonInfo.CourseId);
            lesson.Classroom = await _classroomRepository.GetClassroomById(lessonInfo.ClassroomId);
            lesson.Subject = await _subjectRepository.GetSubjectById(lessonInfo.SubjectId);
            lesson.Teacher = await _teacherRepository.GetTeacherById(lessonInfo.TeacherId);
            await _lessonRepository.InsertLesson(lesson);
            if(lessonInfo.Duration != null)
            {
                 var device = await _microcontrollerRepository.GetDeviceByClassroomId(lesson.Classroom.GetClassroomId());
                 await SendMessageToDevice(lesson, device, MessageOperation.Add);
            }
        }

        public async Task DeleteLesson(Guid id)
        {
            await _lessonRepository.DeleteLesson(id);

        }

        public async Task<LessonInfo> GetLessonById(Guid id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);
            return lesson.ToLessonInfo();
        }

        public  async Task SendLessonBetweenRange(DateTime start)
        {
            var lessons = await  _lessonRepository.GetLessonsByStart(start);
            foreach (var lesson in lessons)
            {
                  var device =  await _microcontrollerRepository.GetDeviceByClassroomId(lesson.Classroom.GetClassroomId());
                  await SendMessageToDevice(lesson, device, MessageOperation.Add);
            }
        }

        private async Task SendMessageToDevice(Lesson lesson, Microcontroller microcontroller, MessageOperation operation)
        {
            if ( microcontroller != null && microcontroller.Gateway.GatewayId == "TestDato")
            {
                var message = lesson.ToDeviceMessage(microcontroller.DeviceId, operation);
                await _iotHubService.SendMessageToDevice(JsonSerializer.Serialize(message), microcontroller.Gateway.GatewayId);
            }
               
        }
    }
}
