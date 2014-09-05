using System;

namespace BDSA12{

    class Program{
	
	static bool IsPowerOf(int a, int b){
        if (a / b == 1)
        {
            Console.WriteLine("{0} / {1} == 1", a, b);
            return true;
        }
        else
        {
            if (a % b == 0) {
                Console.WriteLine("{0} % {1} == 0", a, b);
                return IsPowerOf(a / b, b);
            } else {
                Console.WriteLine("{0} / {1} != 0", a, b);
                return false;
            }
        }
	}
	
	static void Main(string[] args){
	    //MODIFY THIS SECTION TO USE args PARAMETERS
        if (args.Length >= 2)
	        Console.Out.WriteLine(IsPowerOf(Int32.Parse(args[0]),Int32.Parse(args[1])));
        else
            Console.Out.WriteLine("Not enough parameters given!");
        Console.ReadKey();
	}     
    }   
}
