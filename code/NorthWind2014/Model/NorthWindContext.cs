using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public partial class northwindEntities : Context
    {
        public override Context GetContext()
        {
            return new northwindEntities();
        }
    }
}
