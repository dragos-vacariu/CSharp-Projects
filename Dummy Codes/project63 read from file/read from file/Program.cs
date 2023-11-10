/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 12.12.2016
 * Time: 20:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace read_from_file
{
	class Program
	{
		public static void Main(string[] args)
		{
			string textFromFile = System.IO.File.ReadAllText("textfile.txt"); // in this case location of the file is in project folder/debug.
			if(textFromFile!=string.Empty)
			{
				Console.WriteLine("Text From File: \n\n{0}", textFromFile);
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}