using System;

namespace project8_divisible_numbers
{
	class Program
	{
		public static void Main(string[] args)
		{
			divisible_numbers();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void divisible_numbers()
		{
			for(int i=0;i<100;i++)
			{
				if(i%3==0 && i%7==0 && i%9==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 3, 7 and 9.");
				}
				else if(i%3==0 && i%7==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 3, and 7.");
				}
				else if (i%3==0 && i%9==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 3, and 9.");
				}
				else if (i%7==0 && i%9==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 7, and 9.");
				}
				else if (i%3==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 3.");
				}
				else if (i%9==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 9.");
				}
				else if (i%7==0)
				{
					Console.WriteLine("The number " + i + " is divisible by: 7.");
				}
				
			}
		}
	}
}