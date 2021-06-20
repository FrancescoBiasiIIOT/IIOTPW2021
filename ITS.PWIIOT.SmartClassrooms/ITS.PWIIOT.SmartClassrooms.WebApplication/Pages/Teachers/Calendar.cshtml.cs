using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Teachers
{
    public class CalendarModel : PageModel
    {
        public TeacherInfo Teacher { get; set; }
        private readonly ITeacherService _teacherService;

        public CalendarModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task OnGet(string teacherId)
        {
            Teacher = await _teacherService.GetTeacherById(new Guid(teacherId));
        }
    }
}
