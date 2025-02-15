﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.DTO
{
    public class CalendarEvent
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool AllDay { get; set; }
        public string ResourceId { get; set; }
        public DateTime Start { get; set; }
        public string Description { get; set; }

        public DateTime? End { get; set; }

        public CalendarEvent()
        {

        }
    }
    
}
