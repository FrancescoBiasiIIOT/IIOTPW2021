using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Infrastructure
{
    public class SmartClassesContext : DbContext
    {
        public SmartClassesContext(DbContextOptions<SmartClassesContext> options) : base(options)
        {

        }
        public DbSet<Building> Buildings{ get; set; }

    }
}
