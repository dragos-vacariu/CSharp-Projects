/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project18_passing_arguments_by_value_or_reference
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating an instance of the class.
			Program p = new Program();
			int i=0;
			p.byvalue(i); //this function WON'T change the initial value of i.
			Console.WriteLine("The value of i is: {0}", i);
			//sinthax for passing by reference is: 
			//for function call: function(ref variable_name);
			//for function declaration: return_type function_name (ref variable_type variable_name);
			p.byreference(ref i); //BUT this function WILL change the value of i.
			Console.WriteLine("The value of i is: {0}", i);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public void byvalue(int j)
		{
			j=101;
		}
		public void byreference(ref int j) //this is a function with arguments that need to be passed 
			//by reference... using the keyword ref (instead of & like in C++).
		{
			j=101;
		}
	}
}