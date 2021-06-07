using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("FloorBuilding")]
    public class FloorsBuilding : EntityBase<Guid>
    {
        [Required]
        [MinLength(1), MaxLength(2)]
        public FloorState Floor { get; set; }

    }
    public enum FloorState
    {
        PianoTerra = 0,
        PrimoPiano = 1,
        SecondoPiano=2,
       TerzoPiano = 3
    }
}
