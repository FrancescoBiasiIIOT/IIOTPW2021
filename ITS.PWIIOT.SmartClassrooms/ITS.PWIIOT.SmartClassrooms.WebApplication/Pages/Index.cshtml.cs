using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Domain.Lesson> Lessons { get; set; }
        private readonly ILessonRepository lessonRepository;

        public IndexModel(ILogger<IndexModel> logger, ILessonRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        public async Task OnGet()
        {
            Lessons = await lessonRepository.GetLessons(new DateTime(2021,05,05), new DateTime(2021,12,30));
        }
    }
}
