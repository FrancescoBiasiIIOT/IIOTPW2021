using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Courses")]
    public class Course : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
