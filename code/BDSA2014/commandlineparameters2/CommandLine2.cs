﻿using System;

namespace commandlineparameters
{
    class CommandLine2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number of command line parameters = {0}", args.Length);
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
        }
    }
}
