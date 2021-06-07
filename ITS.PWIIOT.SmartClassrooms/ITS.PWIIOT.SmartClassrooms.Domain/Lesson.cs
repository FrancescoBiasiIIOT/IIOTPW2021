using System;
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
        public TimeSpan Duration { get; set; }
    }
}
