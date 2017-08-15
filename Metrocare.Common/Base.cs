using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    [Serializable]
    public abstract class Base
    {
        public Base()
        {
            Id = 0;
            //Guid = Guid.NewGuid();
        }
        public Int32 Id { get; set; }
        //public Guid Guid { get; set; }
    }
}
