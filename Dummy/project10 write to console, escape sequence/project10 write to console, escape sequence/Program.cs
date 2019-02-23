using System; //namespace declaration

namespace project10_write_to_console__escape_sequence
{
	class Program
	{
		public static void Main(string[] args)
		{
			string name = "Deady";
			string path = @"C://movies//file.txt"; //using verbatim literal -> @ make the string treat all the characters
				//as printing characters. The escape sequences are no longer treated as escape sequences, but as
				//printable characters.
				
			//Printing using Place Holder sinthax.
			Console.WriteLine("Hello {0}", name);
			//Printing using Concatenation.
			Console.WriteLine("Hello " + name);
			//Using escape sequence to output "" quotation marks.
			Console.WriteLine("Hello \"{0}\"", name);
			Console.WriteLine("Hello \"" + name + "\"");
			Console.WriteLine("Path: {0}", path);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}