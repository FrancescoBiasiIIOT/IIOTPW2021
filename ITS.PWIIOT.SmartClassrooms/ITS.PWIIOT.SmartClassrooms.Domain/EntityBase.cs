using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
