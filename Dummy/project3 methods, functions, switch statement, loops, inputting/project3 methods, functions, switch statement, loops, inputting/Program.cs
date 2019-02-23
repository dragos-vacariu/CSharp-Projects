using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

class Program
{
	/*Dispite C++ in C# a function without access modifier is set to private. Whereas in C++ were set to public.*/
	static void Main () //by default this function is private
	{
		Console.WriteLine("The program has started!");
		//Calling the function or method:
		Console.WriteLine("The result of addition is: " + add_numbs(10,12));
		
		int numb1,numb2,factorial_term=0;
		int factorial_result=0;
		char litera;
		//Inputting values:
		Console.WriteLine("Type in your values: ");
		numb1=Convert.ToInt32(Console.ReadLine());
		numb2=Convert.ToInt32(Console.ReadLine());
		//Print in the numbers;
		Console.WriteLine("First number is: " + numb1 + "\nSecond number is: " + numb2);
		Console.WriteLine("The result of multiplication is: " + multiply(numb1, numb2));
		//WHILE LOOP
		while (factorial_term>10||factorial_term<1)
		{
			Console.WriteLine("Enter a SEED value between 1 and 10.");
			factorial_term=Convert.ToInt16(Console.ReadLine());
		}
		//FOR LOOP
		for(int i = 1; i<=factorial_term; i++)
		{
			factorial_result+=i;
		}
		Console.WriteLine("The factorial result of your SEED value is: " + factorial_result);
		//DO WHILE LOOP
		do
		{
			Console.WriteLine("This message appear only once!");
		}while(factorial_result<=0);
			litera = Convert.ToChar(Console.ReadLine());
		//Switch Statements
		switch(litera)
		{
			case 'a':
				case 'A':
				{
					Console.WriteLine("The first letter of the alphabet.");
					break;
				}
			case 'b':
				case 'B':
				{
					Console.WriteLine("Second letter of the alphabet.");
					break;
				}
			case 'c':
				case 'C':
				{
					Console.WriteLine("Third letter of the alphabet.");
					break;
				}
			default:
				{
					Console.WriteLine("The alphabet is not starting with this letter.");
					break;
				}
		}
		//Keep the console open.
		Console.ReadKey(true);
	}
	
//Private methods/functions declaration:
private static int add_numbs(int a, int b)
	{
		return a+b;
	}
private static int multiply(int a, int b)
	{
		return a*b;
	}
}