/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 19:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices; //using this for the [Optional] or [OptionalAttribute] attribute

/*WAYS OF ADDING OPTIONAL PARAMETERS:
 * 1.Using params arrays (optional arrays creating using params keyword as prefix).
 * 2.Methods overloading (overloading a method/function to provide many versions with different number of parameters);
 * 3.Methods with default parameter values.
 * 4.Methods that are using optional attribute.
 */

namespace project50_optional_parameters
{
	class Program
	{
		public static void Main(string[] args)
		{
			Program pr = new Program();
			Console.WriteLine("The result of adding 10, 3, 4, 6 is: {0}", pr.AddNumbers(10,3, new int[]{4,6}));
			Console.WriteLine("The result of adding 2 and 5 is: {0}", pr.AddNumbers(2,5));
			//Calling the second function:
			pr.PrintNrs(12);
			//To use the default value only for b (the second argument):
			pr.PrintNrs(1,c:22); //the value of b will be the default value (10);
			//To use default value only for c:
			pr.PrintNrs(1,2); //the value of c will be the default value (2);
			
			//CALLING THE OPTIONAL ATTRIBUTE FUNCTIONS:
			pr.DisplayArgs(1,3);
			pr.DisplayArgs(12,3,11);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Creating functions with default values:
		public int AddNumbers(int num1, int num2, int [] array = null) //sinthax is just like in C++;
		{
			int result=num1+num2;
			if(array!=null)
			{
				foreach (int i in array)
				{
					result+=i;
				}
			}
			return result;
		}
		public void PrintNrs(int a, int b=10, int c=2) //for a function with default parameters, the parameters initialized with
			//default values must be the last in the list of parameters (just like in case of params arrays).
		{
			Console.WriteLine("Nr1= {0}\nNr2= {1}\nNr3= {2}", a, b, c);
		}
		
		//Creating functions with [Optional] attributes
		public void DisplayArgs(int num1, int num2, [Optional] int num3) //this can also be done with [OptionalAttribute].
		{
			//In case that num3 is not specified by the user, it's value will be 0.
			Console.WriteLine("The numbers are: {0}, {1}, {2}", num1,num2,num3);
		}
	}
}