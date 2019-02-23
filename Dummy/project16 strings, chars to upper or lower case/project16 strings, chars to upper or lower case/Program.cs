/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project16_strings_chars_to_upper_or_lower_case
{
	class Program
	{
		public static void Main(string[] args)
		{
			string Usertype;
			Console.WriteLine("Enter a string: ");
			Usertype=Console.ReadLine();
			Console.WriteLine("Your uppercase string is: {0}", Usertype.ToUpper());
			Console.WriteLine("Your lowercase string is: {0}", Usertype.ToLower());
			Console.WriteLine("Enter a character or string to compare to: ");
			string comp = Console.ReadLine();
			Console.WriteLine("Enter a character or string to check for the content: ");
			string content = Console.ReadLine();
			Console.WriteLine("Comparation: {0}", Usertype.CompareTo(comp));
			Console.WriteLine("Contains {0}: {1}", content, Usertype.Contains(content));
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}