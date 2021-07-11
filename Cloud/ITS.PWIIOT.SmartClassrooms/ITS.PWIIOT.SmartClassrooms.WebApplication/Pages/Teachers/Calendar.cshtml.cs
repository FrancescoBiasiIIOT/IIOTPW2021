using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Teachers
{
    public class CalendarModel : PageModel
    {
        public TeacherInfo Teacher { get; set; }
        private readonly ITeacherService _teacherService;
        private readonly IClassroomService classroomService;
        public IEnumerable<ClassroomInfo> Classrooms { get; set; }

        public CalendarModel(ITeacherService teacherService, IClassroomService classroomService)
        {
            _teacherService = teacherService;
            this.classroomService = classroomService;
        }

        public async Task OnGet(string teacherId)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                RedirectToPage("Index");
            }

            Classrooms = await classroomService.GetClassrooms();
            Teacher = await _teacherService.GetTeacherById(new Guid(teacherId));
        }
    }
}
