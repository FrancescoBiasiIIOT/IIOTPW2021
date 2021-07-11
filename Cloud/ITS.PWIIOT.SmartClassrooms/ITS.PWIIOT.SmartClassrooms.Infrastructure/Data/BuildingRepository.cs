using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Infrastructure.Data
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public BuildingRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            var buildings = await _smartClassesContext.Buildings
                .Include(b => b.Classrooms)
                .ToListAsync();

            return buildings;
        }
    }
}
