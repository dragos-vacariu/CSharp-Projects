/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 15:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for the List

/*An attribute is a declared way of showing warnings. A declared way of providing information.*/

/*Classes are usually called types, and can be used only as internal or public classes (only these 2 access modifiers are allowed when
related to a class), a field of a class is set to be private by default. For field (and type members) there are all 5 access modifiers 
availalble, for usage.*/
namespace project42_attributes
{
	class Program //this class is set by default to be internal
	{
		public static void Main(string[] args)
		{
			Calculator calc = new Calculator();
			Console.WriteLine("Sum: {0}",calc.Add(12,14));
			Console.WriteLine("Sum2: {0}", calc.Add(new List<int>{1,2,3,23})); //calling the second method (updated method).
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Calculator //this class is set by default to be internal.
	{
		//This method can add only 2 numbers. It's an outdated version of the same method/function, to show a warning about that
		//we could make use of an attribute:
		
		//This is the default warning:
		//[Obsolete] //obsolete means that the method is outdated. This will show a warning when the compilation starts.
		
		[Obsolete("Use Add(List<int> numbers) Method instead!")] //with this sequence you can pass a custom message to the warning.
		
		//[Obsolete("Use Add(List<int> numbers) Method instead!", true)]//sinthax to raise a compilation error if the user uses the 
		//Obsolete (outdated) function.
		
		//An attribute will never affect the compilation status... or the runtime. An attribute is just a way to provide
		//information in a declared way.
		public int Add (int numb1, int numb2) //this method can add only 2 numbers
		{
			return numb1+numb2;
		}
		public int Add(List<int> numbers) //this method can add as many numbers as the user wants.
		{
			int result=0;
			foreach(int k in numbers)
			{
				result+=k;
			}
			return result;
		}
	}
}