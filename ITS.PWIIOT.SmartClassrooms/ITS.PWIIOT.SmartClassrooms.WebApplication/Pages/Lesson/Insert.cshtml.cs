using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Lesson
{
    public class InsertModel : PageModel
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILessonRepository _lessonRepository;
        public InsertModel(IClassroomRepository classroomRepository, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, ILessonRepository lessonRepository)
        {
            Teachers = new List<Teacher>();
            Classrooms = new List<Classroom>();
            Subjects = new List<Subject>();
            _classroomRepository = classroomRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
        }

        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public Domain.Lesson Lesson { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }
        public async Task OnGet()
        {
            Lesson = new Domain.Lesson();
            Classrooms = await _classroomRepository.GetClassrooms();
            Subjects = await _subjectRepository.GetSubjects();
            Teachers = await _teacherRepository.GetTeachers();
        }

        public async Task OnPost()
        {
            Lesson.Classroom = await _classroomRepository.GetById(Lesson.ClassroomId);
            Lesson.Teacher = await _teacherRepository.GetTeacherById(Lesson.TeacherId);
            Lesson.Subject = await _subjectRepository.GetSubjectById(Lesson.SubjectId);
            await _lessonRepository.InsertLesson(Lesson);
            RedirectToPage("/Index");
        }
    }
}
