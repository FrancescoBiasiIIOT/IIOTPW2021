using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Classroom
{
    public class CalendarModel : PageModel
    {
        private readonly IClassroomService _classroomService;

        public CalendarModel(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        public ClassroomInfo Classroom { get; set; }
        public async Task OnGet(string classroomId)
        {
            Classroom = await _classroomService.GetClassroomById(classroomId);
        }
    }
}
