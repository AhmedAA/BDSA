using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversepolishcalculator
{
    interface IOperation
    {
        double Execute(double first, params double[] rest);
    }
}
