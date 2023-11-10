/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.12.2016
 * Time: 18:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project68_random_numbers
{
	class Program
	{
		public static void Main(string[] args)
		{
			Random i = new Random();
			int nr;
			nr=i.Next(1,5);
			Console.WriteLine("Value: {0}",nr);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}