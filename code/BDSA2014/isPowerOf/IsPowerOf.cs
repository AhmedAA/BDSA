using System;

namespace isPowerof{

    class Program{
	
	static bool IsPowerOf(int a, int b){
        while (a >= b)
        {
            if (a / b == 1)
            {
                return true;
            }

            IsPowerOf(a / b, b);
        }

        return false;
    }
	
	static void Main(string[] args){
	    //MODIFY THIS SECTION TO USE args PARAMETERS
	    Console.Out.WriteLine(IsPowerOf(27,3));
        Console.Out.WriteLine(IsPowerOf(int.Parse(args[0]), int.Parse(args[1])));
        Console.ReadKey();
	}     
    }   
}