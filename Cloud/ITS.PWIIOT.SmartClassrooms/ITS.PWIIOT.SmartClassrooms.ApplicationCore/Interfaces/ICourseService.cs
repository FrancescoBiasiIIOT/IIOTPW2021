﻿using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseInfo>> GetCourses();
        Task<CourseInfo> GetCourseById(Guid id);
    }
}
