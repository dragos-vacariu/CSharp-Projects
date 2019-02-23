/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 20:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text; // using this for StringBuilder.
/*A stringbuilder is a data type just like string. The main difference between them is that the stringbuilder is mutable.
 Mutable means that once that is created the string can be changed, whereas System.string is not mutable, once created
 cannot be change. If you try to change a string after it was been initialized, the system will create another object of the string in
 memory and pass the new value of the string to that object, but the old object which holds the old value of the string will not be cleaned
 until the end of the program, when the garbage collector does its work.
 A stringbuilder should be used everytime when a string that's created tends to change its value, in this way, only a single object will
 be created in memory no matter how many times its value it will change, because it's mutable.
 */

namespace project46_working_with_string_builder
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating a stringbuilder:
			StringBuilder stringbuiler = new StringBuilder("Adam"); //this is how a stringbuilder gets created and initialized
			//To concatenate string builders, there is a function called .Append();
			stringbuiler.Append(" has");
			stringbuiler.Append(" C#");
			stringbuiler.Append(" skills!");
			//Printing the stringbuilder:
			Console.WriteLine("{0}", stringbuiler);
			Console.WriteLine("{0}", stringbuiler.ToString()); //this is a better way to print the stringbuilder
			//Other stringbuilder operations:
			stringbuiler.Clear(); //clear the stringbuiler's content
			Console.WriteLine("{0}", stringbuiler);
			Console.WriteLine("Stringbuilder Capacity: {0}", stringbuiler.Capacity); //stringbuilder.Capacity returns the capacity of the
			//stringbuilder
			Console.WriteLine("Stingbuilder Max Capacity: {0}",stringbuiler.MaxCapacity);
			
			//End of program:
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}