using System;

namespace isPowerof{

    class Program{
	
	static bool IsPowerOf(int a, int b){
        //If a becomes less than b, then a is not a power of b
        while (a >= b)
        {
            //if a/b=1, then a=b and a should therefore be a power of b
            if (a / b == 1)
            {
                return true;
            }

            //if a/b != 0, and a is still bigger than b, then we make the recursive call where a is now a/b
            a = a/b;
            IsPowerOf(a, b);
        }

        return false;
    }
	
	static void Main(string[] args){
	    //MODIFY THIS SECTION TO USE args PARAMETERS
	    Console.Out.WriteLine(IsPowerOf(27,3));
        //We parse the arguments from the commandline. If there aren't any, the program will just exit.
        Console.Out.WriteLine(IsPowerOf(int.Parse(args[0]), int.Parse(args[1])));
        Console.ReadKey();
	}     
    }   
}