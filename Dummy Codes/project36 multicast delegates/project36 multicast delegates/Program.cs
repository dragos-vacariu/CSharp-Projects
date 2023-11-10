/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

/*A multicast delegate is a delegate that can point to multiple functions in the same time.
 */
public delegate void SimpleDelegate (); //a delegate that takes no arguments, and doesn't return anything.

namespace project36_multicast_delegates
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("First method:\n");
			//Method 1 of enchaining delegates together in multicast delegates.
			//Creating an instance of the delegate.
			SimpleDelegate d1,d2,d3,d4;
			d1 = new SimpleDelegate(PrintMessage1); //d1 will point to PrintMessage1
			d2 = new SimpleDelegate(PrintMessage2); //d2 will point to PrintMessage2
			d3 = new SimpleDelegate(PrintMessage3); //d3 will point to PrintMessage3
			d4 = d1+d2+d3; //d4 will now be a multicast delegate that will point to more than 1 function.
			//Calling the delegate 4
			d4(); //the delegate 4 will call 3 function in the same time.
			//IF WE WANT TO REMOVE A FUNCTION FROM THE DELEGATE:
			Console.WriteLine("After removal:");
			//Adding function to a delegate it's called registering to delegate. Subtracting function from the
			//delegate it's called unregistering out of the delegate.
			d4-=PrintMessage2;
			d4();
			
			//Method 2:
			Console.WriteLine("\nSecond method:\n");
			SimpleDelegate d5 = new SimpleDelegate(PrintMessage1);
			d5+=PrintMessage2; // now d5 is a multicast delegate;
			d5();
			//For a function that returns a value, the delegate will follow the chain of function (if the same
			//delegate is poiting to more functions), and will return the values from all the function, but when
			//trying to hold the value into a variable, only the value returned by the last function enchained 
			//will be hold, because a variable can hold only one value at a time. Similar if a function has 
			//output parameters the delegate will follow the chain (if it's multicast delegate), and the value 
			//returned in the output parameter will be the value from the last function enchained.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Example functions:
		public static void PrintMessage1()
		{
			Console.WriteLine("This is the 1st function.");
		}
		public static void PrintMessage2()
		{
			Console.WriteLine("This is the 2nd function.");
		}
		public static void PrintMessage3()
		{
			Console.WriteLine("This is the 3rd function.");
		}
	}
}