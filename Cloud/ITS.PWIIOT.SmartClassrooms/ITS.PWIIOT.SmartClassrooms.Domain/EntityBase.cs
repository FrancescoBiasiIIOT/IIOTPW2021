﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    public abstract class EntityBase<T>
    {
        [Key]
        [Required]
        public T Id { get; set; }
    }
}
