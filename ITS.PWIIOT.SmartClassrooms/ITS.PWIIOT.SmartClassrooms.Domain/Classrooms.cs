using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;


namespace ITS.PWIIOT.SmartClassrooms.Domain
{
   
        [Table("Classrooms")]
        public class Classrooms : EntityBase<Guid>
        {
             [Required]
             [MinLength(1), MaxLength(10)]
             public string Name { get; set; }

             [Required]
             [MinLength(1), MaxLength(2)]
             public ClassroomState State { get; set; }

             public int Capacity { get; set; }
        }
        public enum ClassroomState
    {
        PianoTerra = 0,
        PrimoPiano = 1,
        SecondoPiano= 2,
        TerzoPiano = 3
    }
    }

