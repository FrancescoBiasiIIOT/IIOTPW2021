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
        public int? Duration { get; set; }
        public string ClassroomId { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid SubjectId { get; set; }

        public TimeSpan GetDuration()
        {
            return EndDate.Value.Subtract(StartDate);

        }

        public bool IsLessonValid()
        {
            bool isValid = true;
            if (ClassroomId == "" || TeacherId == Guid.Empty || CourseId == Guid.Empty || SubjectId == Guid.Empty)
            {
                isValid = !isValid;
            }
            return isValid;
        }
    }
}
