using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Teachers")]
    public class Teacher : EntityBase<Guid>
    {
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
