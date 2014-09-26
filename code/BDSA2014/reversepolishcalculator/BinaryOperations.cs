using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversepolishcalculator
{
    class BinaryOperations : IOperation
    {
        private readonly ReversePolishCalculatorV2.Delegate _func;

            public BinaryOperations(ReversePolishCalculatorV2.Delegate func)
            {
                _func = func;
            }

            //Since it is binary, two arguments are used
            public double Execute(double first, params double[] rest)
            {
                return _func(first, rest[0]);
            }
    }
}
