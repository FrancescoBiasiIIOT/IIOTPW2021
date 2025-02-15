﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Lessons")]
    public class Lesson : EntityBase<Guid>
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public Classroom Classroom { get; set; }
        public Guid ClassroomId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
        public Subject Subject { get; set; }
        public Guid SubjectId { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }


        public TimeSpan GetDuration()
        {
            var test =  EndDate.Subtract(StartDate);
            return test;
        }
    }

    
}
