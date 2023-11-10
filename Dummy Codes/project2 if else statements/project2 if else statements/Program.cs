using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace project2_if_else_statements
{
	class Program
	{
		public void Main() //IN C# the main function must be STATIC.
		{
			//In C# the Main function MUST BE included within a class.
			int age = 22;
			if(age > 22) // in C# if statements works just like in C++
			{
				Console.WriteLine("You are older than me!");
			}
			else if(age < 22)
			{
				Console.WriteLine("You are younger than me!");
			}
			else
				Console.WriteLine("We have the same age!");
			//From here on: we are out of the if statement.
			Console.ReadLine();
			
			return;
		}
	};
};