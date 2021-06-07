using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Teaches")]
    public class Teaches : EntityBase<Guid>
    {
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
