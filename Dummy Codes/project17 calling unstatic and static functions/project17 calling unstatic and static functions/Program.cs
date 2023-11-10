/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 15:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project17_calling_unstatic_function__instances
{
	class Program
	{
		public static void Main(string[] args)
		{
			//In order to call unstatic function into this main static function, you have to
			//create an object of the class (an object is also called an instance).
			//sinthax to create an object:
			Program p = new Program(); //p is now the instance or the object of the class Program.
			p.unStaticfunction(); //calling or invoking the INSTANCE function
			Program.Staticfunct();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Unstatic methods or functions are called INSTANCE methods or functions, because
		//they need an instance of the class in order to be called.
		public void unStaticfunction() //this is an INSTANCE FUNCTION
		{
			Console.WriteLine("This is unstatic function. Called with instance of the class");
		}
		public static void Staticfunct()
		{
			Console.WriteLine("This is static function. Called with qualify name of the class.");
		}
	}
}