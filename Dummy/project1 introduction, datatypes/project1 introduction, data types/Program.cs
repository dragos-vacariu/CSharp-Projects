using System; // used instead of includes

/*
 The other libraries:

 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.Collections.Generic;
 */

namespace project1_introduction //this namespace statement is like a folder.
{
	class Program
	{
		public static void Main(string[] args) //the main function starts here;
		{ 
			//string[] args is an optional argument;
			
			//function to print on the screen;
			Console.WriteLine("Hello World!");
			//Data types:
			int numb_one = 5;
			float numb_two = 6.034f;
			double numb_three = 3.0;
			bool istrue = false;
			string name = "Black";
			object ANYTHING = "A variable that can be initialized with anything!";
			char character = 'X';
			
			//Printing the result on the screen;
			Console.Write("The result of addition is: " + (numb_one+numb_two) + "\n");
			Console.WriteLine("An object is: " + "\"" + ANYTHING + "\"");
			/*
 			Console.WriteLine - automatically puts '\n' at the end of the line, because it is a function
			designed to be used only for writing a line.
			 */
			
			Console.Write(character + "\n");
			Console.WriteLine("Processing data!\n\n");
			while (numb_one>0)
			{
				if(numb_one==1)
				{
					Console.WriteLine("The program will end.\n\n");
				}
				numb_one--;
			}
			Console.Write("Press any key to continue . . . ");
			//function to read keys;
			Console.ReadKey(true);
		}
	}
}