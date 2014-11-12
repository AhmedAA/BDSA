using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    class NorthWindContextFactory : IContextFactory
    {
        public Context CreateContext()
        {
            return new northwindEntities();
        }
    }
}
