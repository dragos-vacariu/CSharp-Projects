/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 16:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*A delegate is a type safe pointer to a function. Type safe means that the signature of the function must match
 the signature of the delegate.*/

//Creating a delegate
public delegate void SayHelloFunct(string message);
namespace project34_delegates
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*In order to use a delegate an instance of it must be created.*/
			SayHelloFunct c1 = new SayHelloFunct(SayHello); //the way that an instance is created
			c1("Frank"); //invoking the delegate.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void SayHello(string name)
		{
			Console.WriteLine("Hello {0}", name);
		}
	}
}