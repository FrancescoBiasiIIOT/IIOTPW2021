using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Subjects")]
    public class Subject : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        [MinLength(1), MaxLength(150)]
        public string Description { get; set; }
    }
}
