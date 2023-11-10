/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 20.07.2016
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO; //namespace for files.

/*DISADVANTAGES OF UNHANDLING EXCEPTION:
 An unhandled exception would provide annoying error message to a user, which could make the program be devoid
 using.
 An unhandled exception could also provide important information to a hacker.
 */
 //While handling the exceptions the catch block containing the specific Classes must be above 
 //the general Class which should be the last one at the bottom.
namespace project37_read_write_to_files_handling_exceptions
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			//Creating a file read streamer:
			StreamReader readFromFile = new StreamReader(@"D:\error.txt"); // @ -> using the escape sequence
			//EXCEPTION HANDLING:
			try //try to do this without exception
			{
				Console.WriteLine(readFromFile.ReadToEnd()); //ReadToEnd will read all the content of the file (until the end).
			}
			//If there was an exception come to this catch statement
			//THIS IS A SPECIFIC CATCH, this is the child of EXCEPTION CLASS
			catch(FileNotFoundException fNotFound) //try to handle the exception with this object.
				//This object is mostly for FileNotFoundException.
			{
				//AN object of type FileNotFoundException contain more information about the file that could 
				//not be found then an object of type Exception (as we use in our case).
				Console.WriteLine(fNotFound.Message);
				Console.WriteLine("Check for the file: {0}", fNotFound.FileName);
			}
			//If the catch above was not able to handle the exception try this one:
			//THIS IS THE GENERAL CATCH (Exception class is the parent of all the other classes above.)
			catch(Exception ex) //this can handle also the DirectoryNotFoundException.
			{
				Console.WriteLine(ex.Message);
			}
			//THIS BLOCK IS ALWAYS EXECUTED while for the catch blocks is not a certainty which one is going to
			//be executed.
			finally //the finally block contain the code that should be executed by all means necessary
			{
				if(readFromFile!=null) //if the file is null then it cannot be closed.
				{
					readFromFile.Close();
				}
			}
			//END OF EXCEPTION HANDLING.
			StreamWriter writeToFile = new StreamWriter(@"D:\writeToFile.txt");
			writeToFile.WriteLine("Project37 Read write to files, exeption handling Finally!");
			writeToFile.Close(); //the filestream needs to be closed for the writing to work.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}