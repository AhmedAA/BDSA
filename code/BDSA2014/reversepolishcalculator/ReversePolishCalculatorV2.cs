using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace reversepolishcalculator
{
    /// <summary>
    /// Version 2.0
    /// This is the Reverse Polish Calculator with added delegates and unary/binary operations.
    /// written by ahaq@itu, mikx@itu and ppho@itu
    /// 25-09-2014
    /// </summary>
    public class ReversePolishCalculatorV2
    {
        public delegate double Delegate(double first, params double[] rest);
        private readonly Dictionary<String, IOperation> _operations = new Dictionary<string, IOperation>();
        private readonly Stack<double> _stack = new Stack<double>();

        /// <summary>
        /// Constructor handles userinput, checks for common errors and send it to determine operation.
        /// </summary>
        /// <param name="input">separated by whitespace. Decimals with comma.</param>
        public ReversePolishCalculatorV2(string input)
        {

            string[] inputSplit = input.Split(' ');
            AddOperations();

            //Gives the rpc all arguments one by one
            foreach (String tmp in inputSplit.Where(tmp => !string.IsNullOrWhiteSpace(tmp)))
            {
                DetermineOperation(tmp);
            }
        }

        /// <summary>
        /// Main method instantiates program and catches exceptions. The only method with printout.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Write reverse polish calculator input now:");
            try
            {
                // The users input string is given to the constructor.
                var rpc = new ReversePolishCalculatorV2(Console.ReadLine());
                Console.WriteLine("Result is: " + rpc.Result());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (InvalidOperationException ioe)
            {
                //When user inputs not enough numbers or operators and the stack tries to pop empty
                Console.WriteLine(ioe.Message);
            }
            Main(null); //Just to keep the console running for easier testing.
        }

        //The various operations the calculator can handle, and how it calculates them, are added to the dictionary
        private void AddOperations()
        {
            _operations.Add("+", new BinaryOperations((first, rest) => rest[0] + first));
            _operations.Add("-", new BinaryOperations((first, rest) => rest[0] - first));
            _operations.Add("/", new BinaryOperations((first, rest) => rest[0]/first));
            _operations.Add("*", new BinaryOperations((first, rest) => rest[0]*first));
            _operations.Add("pow", new BinaryOperations((first, rest) => Math.Pow(rest[0], first)));
            _operations.Add("^", new BinaryOperations((first, rest) => Math.Pow(rest[0], first)));
            _operations.Add("sqrt", new UnaryOperations((first, rest) => Math.Sqrt(first)));
            _operations.Add("abs", new UnaryOperations((first, rest) => Math.Abs(first)));
        }

        //Determines whether the argument is Unary, Binary or another value and handles them accordingly
        private void DetermineOperation(string temp)
        {
            IOperation operation;
            _operations.TryGetValue(temp, out operation);
            double number;

            if (operation is UnaryOperations)
                _stack.Push(operation.Execute(_stack.Pop(), null));

            else if (operation is BinaryOperations)
                _stack.Push(operation.Execute(_stack.Pop(), new[] {_stack.Pop()}));

            //If it's not an operator it must be a number
            else if (Double.TryParse(temp, out number))
            {
                _stack.Push(number);
            }
        }
    
        //Returns the result when there is only one number left in the stack
        public double Result()
        {
            //If the stack count is larger than one at this point, the input had too many operators or not enough values
            if (_stack.Count > 1)
            {
                throw new ArgumentException("User input error");
            }
            //If the stack count is zero at this point, the input was null or empty
            if (_stack.Count == 0)
            {
                throw new ArgumentException("No input given");
            }
            //The remainder from the calculation is returned as the result
            return (_stack.Pop());
        }
    }
}