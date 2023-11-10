/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 19:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*The generic is a specification that allows to a function/method or class to operate without depending on the data type that's been taking 
 * as parameters, and without losing the strong typed property of the function, and the performance.
 *Generics were introduced in C# 2.0, and they are used especially for class collections.
 * 
* The conversion from value type to reference type is called boxing. When we talk about performance provided by generics, we mean that
* no boxing will be effectuated. Boxing are weak in performance.
 */

namespace project45_generics
{
	class Program
	{
		public static void Main(string[] args)
		{
			Program aProg = new Program();
			//Using the generic function:
			bool result = aProg.IsEqual<int> (21,44); //the function works for any data type.
			Console.WriteLine("Result of the comparison: {0}", result);
			result = aProg.IsEqual<string> ("Adam", "Exit"); //the function works for any data type.
			Console.WriteLine("Result of the comparison: {0}", result);
			result = aProg.IsEqual<char>('a', 'a'); //the function works for any data type.
			Console.WriteLine("Result of the comparison: {0}", result);
			
			//Working with the generic class:
			MyClass<int> GenCls = new MyClass<int>();
			GenCls.printStuff(12,3);
			MyClass<string> GenCls2 = new MyClass<string>();
			GenCls2.printStuff("Deady", "Online");
			//End of program.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Creating a generic function:
		public bool IsEqual <T> (T value1, T value2) //the parameters are of type T, into that type could be encapsulated any data type.
		{
			return value1.Equals(value2);
		}
		//The sinthax to create a generic function is: access_modifier return_type function_name <variable_type_name> (arguments of 
		//variable_type_name).
	}
	//Creating a generic class
	#region GenericClass //this is how you can structure your code using regions
	class MyClass <A> //the sinthax is class Class_Name <variable_type_name>
	{
		//Creating a function for the generic class.
		public void printStuff(A value1, A value2)
		{
			Console.WriteLine("The stuff sent is: {0} && {1}", value1, value2);
		}
	}
	#endregion //end of the region
}