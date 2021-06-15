using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.DTO
{
    public class LessonInfo
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public string ClassroomId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }
        public Guid SubjectId { get; set; }

        public TimeSpan GetDuration()
        {
            return EndDate.Value.Subtract(StartDate);

        }
    }
}
