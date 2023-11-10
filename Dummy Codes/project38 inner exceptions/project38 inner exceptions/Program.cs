/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 20.07.2016
 * Time: 17:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO; //using this for file reading and file writing.

namespace project38_inner_exceptions
{
	class Program
	{
		public static void Main(string[] args)
		{
			try //Outer
			{
				try //Inner
				{
					Console.WriteLine("Enter your first number:");
					int numb1 = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Enter your second number:");
					int numb2 = Convert.ToInt32(Console.ReadLine());
					int Result = numb1/numb2;
					Console.WriteLine("Result={0}", Result);
				}
				//Inner:
				//if there was an exception then the catch block will execute.
				catch(Exception exp) //this is the inner exception because it's inside another exception's block.
				{
					Console.WriteLine(exp.Message);
					Console.WriteLine(exp.GetType().Name); //GetType().Name gets the type of exception and print its name
					Console.WriteLine(exp.GetType().FullName); //GetType().FullName gets the type of exception and 
					//prints its full name.
				
					//GET THE INFOLOG:
					string filepath = @"D:\InfoLog.txt";
					StreamWriter fileLog = new StreamWriter(filepath);
					if(File.Exists(filepath))
					{
						fileLog.WriteLine(exp.Message);
						fileLog.WriteLine(exp.GetType().Name);
						fileLog.Close();
					}
					else
					{
					//IMPORTANT: You cannot throw multiple exceptions of the same type.
					//As we have thrown above (in catch block) the an exception of type Exception, we now
					//need to use another type of exception.
						throw new FileNotFoundException("File at: {0} -> could not be found.", filepath);
						//the exception for this will be handled as the outter exception, in the catch block
						//below.
					}
				}
			}
			catch (Exception exception) //Outer
			{
				Console.WriteLine("The current exception: {0}", exception.GetType().Name);
				if(exception.InnerException!=null) //the inner exception becomes null, when the system
					//already handled the code from the inner catch block above.
				{
					Console.WriteLine("The inner exception: {0}", exception.InnerException.GetType().Name);
				}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}