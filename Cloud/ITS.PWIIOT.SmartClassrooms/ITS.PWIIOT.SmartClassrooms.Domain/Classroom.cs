﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;


namespace ITS.PWIIOT.SmartClassrooms.Domain
{

    [Table("Classrooms")]
    public class Classroom : EntityBase<Guid>
    {
        [Required]
        [MinLength(1), MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public ClassroomState State { get; set; }
        public int Capacity { get; set; }
        public Building Building { get; set; }

        public string GetClassroomId()
        {
            return Building?.Name + Name;
        }

        public void SetAvailable()
        {
            if(State != ClassroomState.Occupata)
            {
                throw new Exception("impossibile cambiare lo stato della classe");
            }
            State = ClassroomState.Libero;
        }
        public void SetBusy()
        {
            State = ClassroomState.Occupata;
        }

    }
    public enum FloorState
    {
        PianoTerra = 0,
        PrimoPiano = 1,
        SecondoPiano = 2,
        TerzoPiano = 3
    }
    public enum ClassroomState
    {
        Libero = 0,
        Occupata = 1
    }
}

