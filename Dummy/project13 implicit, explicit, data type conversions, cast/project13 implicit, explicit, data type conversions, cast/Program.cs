/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 16.07.2016
 * Time: 15:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project13_implicit__explicit__data_type_conversions
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*An implicit conversion is done by the compiler when there are no loss of information. Also there is
			 * no possibility of throwing exceptions during the conversion.
			 * Example:
			 */
			int numb1 = 100;
			float numb2 = numb1; //implicit conversion (done by the compiler).
			Console.WriteLine("The value of numb2 is: {0}", numb2);
			/*An explicit conversion is done by the programmer using type cast operators or predefined classes, 
 			* data-conversion classes.
			 Example:
			 */
			float numb3=123.543f;
			numb1 = (int) numb3; //explicit conversion using type cast.
			Console.WriteLine("The value of numb1 is: {0}", numb1);
			numb1 = Convert.ToInt32(numb3); //explicit conversion using Conversion Class.
			Console.WriteLine("The value of numb1 is: {0}", numb1);
			/* Conversion Class - will throw an exception/message when the conversion fails because one variable
			 * can't hold the value of the converted one.
			 * Type Cast - will not throw any exception, will just print the minimum value that the variable 
			 * can hold. 
			 */
			
			//Parse Methods of converting string to int.
			string valueN = "199";
			numb1 = int.Parse(valueN); //parsing sinthax
			//in case if the string does not contain a valid number, an exception will be thrown. SO the program
			//will be terminated.
			Console.WriteLine("The value of numb1 after parsing is: {0}", numb1);
			
			//TryParse Methods of converting string to int.
			string valueB = "221a";
			int Result = 0;
			bool Success = int.TryParse(valueB, out Result); //sinthax of TryParse.	
			//if int.TryParsing is succesfull the bool Success will become true, else it will become false.
			//TryParse takes 2 arguments: the string to be converted and the variable that will stored the
			//converted result (if it is successful). If the TryParse is not successful the Result will not be 
			//changed.
			if(Success)
			{
				Console.WriteLine("The value of numb1 after tryparsing is: {0}", Result );
			}
			else
			{
				Console.WriteLine("The number is invalid. The conversion was unsuccesful!");
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}