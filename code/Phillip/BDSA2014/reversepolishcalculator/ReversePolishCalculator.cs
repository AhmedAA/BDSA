using System;
using System.Collections.Generic;

namespace reversepolishcalculator
{
    public class ReversePolishCalculator
    {
        static void Main(string[] args)
        {
            // This calculator only takes one input string at a time. It could be expanded to take more late.
            if (args.Length == 1)
            {
                try
                {
                    // The input string is given to the calculate function.
                    String result = Calculate(args[0]);
                    Console.WriteLine("Result: " + result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Too few or too many inputs! Write one input only!");
            }
        }

        // Input strings should be in the form of integers and operators, separated with a space.
        public static string Calculate(string input)
        {
            // If input string is empty or null, return "0".
            if (input == null || input.Equals(""))
            {
                return "0";
            }

            // Split the input into separate items (" " as delimeter) and create an empty stack.
            String[] items = input.Split(new Char[] { ' ' });
            var stack = new Stack<Decimal>();

            // Loop through each item from the input string and determine the action.
            foreach (string item in items)
            {

                int number;
                if (Int32.TryParse(item, out number))
                {
                    stack.Push(number);
                    Console.Write("Stack:");
                    foreach (Decimal stackNumber in stack)
                    {
                        Console.Write(" " + stackNumber);
                    }
                    Console.WriteLine();
                }
                else if (item.Equals("+"))
                {
                    // If operator is an addition, add the numbers, if two numbers are present on the stack.
                    if (stack.Count >= 2)
                    {
                        Decimal firstNumber = stack.Pop();
                        Decimal secondNumber = stack.Pop();
                        Decimal result = secondNumber + firstNumber;
                        stack.Push(result);
                        Console.WriteLine("Operation: " + secondNumber + " + " + firstNumber + " = " + result);
                    }
                    else
                    {
                        // Throw exception, since there wasn't enough numbers.
                        throw new ArgumentException("Error in input. Not enough arguments for add operation!");
                    }
                }
                else if (item.Equals("-"))
                {
                    // If operator is a subtraction, subtract the numbers, if two numbers are present on the stack.
                    if (stack.Count >= 2)
                    {
                        Decimal firstNumber = stack.Pop();
                        Decimal secondNumber = stack.Pop();
                        Decimal result = secondNumber - firstNumber;
                        stack.Push(result);
                        Console.WriteLine("Operation: " + secondNumber + " - " + firstNumber + " = " + result);
                    }
                    else
                    {
                        // Throw exception, since there wasn't enough numbers.
                        throw new ArgumentException("Error in input. Not enough arguments for subtraction operation!");
                    }
                }
                else if (item.Equals("*"))
                {
                    // If operator is a multiplication, multiply the numbers, if two numbers are present on the stack.
                    if (stack.Count >= 2)
                    {
                        Decimal firstNumber = stack.Pop();
                        Decimal secondNumber = stack.Pop();
                        Decimal result = secondNumber * firstNumber;
                        stack.Push(result);
                        Console.WriteLine("Operation: " + secondNumber + " * " + firstNumber + " = " + result);
                    }
                    else
                    {
                        // Throw exception, since there wasn't enough numbers.
                        throw new ArgumentException("Error in input. Not enough arguments for multiplication operation!");
                    }
                }
                else if (item.Equals("/"))
                {
                    // If operator is a division, divide the numbers, if two numbers are present on the stack.
                    if (stack.Count >= 2)
                    {
                        Decimal firstNumber = stack.Pop();
                        Decimal secondNumber = stack.Pop();
                        Decimal result = secondNumber / firstNumber;
                        stack.Push(result);
                        Console.WriteLine("Operation: " + secondNumber + " / " + firstNumber + " = " + result);
                    }
                    else
                    {
                        // Throw exception, since there wasn't enough numbers.
                        throw new ArgumentException("Error in input. Not enough arguments for division operation!");
                    }
                }
                else
                {
                    // The item isn't an accepted operator. Throw an exception.
                    throw new ArgumentException("Error in input. Operator not reckognized: " + item);
                }
                Console.Write("Stack:");
                foreach (Decimal stackNumber in stack)
                {
                    Console.Write(" " + stackNumber);
                }
                Console.WriteLine();
            }

            // Build the result string.
            if (stack.Count > 1 || stack.Count < 1)
            {
                throw new ArgumentException("Error in input. Missing numbers or operators has resulted in an error!");
            }
            
            return stack.Pop().ToString();
        }
    }
}
