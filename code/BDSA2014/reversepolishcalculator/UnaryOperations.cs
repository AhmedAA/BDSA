using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversepolishcalculator
{
    class UnaryOperations : IOperation
    {
            private readonly ReversePolishCalculatorV2.Delegate _func;

            public UnaryOperations(ReversePolishCalculatorV2.Delegate func)
            {
                _func = func;
            }

            //Since it is unary, only the first argument is used
            public double Execute(double first, params double[] rest)
            {
                return _func(first);
            }
    }
}
