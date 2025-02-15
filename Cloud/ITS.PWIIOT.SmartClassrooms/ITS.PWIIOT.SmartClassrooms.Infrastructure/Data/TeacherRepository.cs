﻿using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Infrastructure.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public TeacherRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            var teachers = await _smartClassesContext.Teachers
                .ToListAsync();

            return teachers;
        }

        public async Task<Teacher> GetTeacherById(Guid id)
        {
            return await _smartClassesContext.
                Teachers.Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Teacher> GetTeacherByEmaail(string email)
        {
            return await _smartClassesContext.
            Teachers.Where(t => t.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
