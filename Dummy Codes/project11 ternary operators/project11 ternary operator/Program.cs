using System;

namespace project11_ternary_operator
{
	class Program
	{
		public static void Main(string[] args)
		{
			bool istrue;
			int simpletest;
			int number = 10;
			//Ternary Operator "?"
			istrue = number==10 ? true : false;
			//sinthax: boolean variable = condition ? value for true : value for false
			
			/*Equivalence of that:
			 * if(number==10)
			 * {
			 * 		istrue=true;
			 * }
			 * else
			 * {
			 * 		istrue=false;
			 * }
			 */
			Console.WriteLine("The value of istrue is: {0}", istrue);
			//Other example:
			simpletest = number==10 ? 10+2 : 10-2;
			Console.WriteLine("The value of simpletest is: {0}", simpletest);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}