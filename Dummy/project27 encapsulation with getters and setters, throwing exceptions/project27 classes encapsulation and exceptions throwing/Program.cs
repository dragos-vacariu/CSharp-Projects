/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

/*Members of the class should never be set to public, because public means that anyone who works at that program
 *is able to change the variable's value, so to avoid that, all the members (sometimes called proprieties), should
 * be private, (or protected for inheritance purposes).
 * Encapsulation - is the use of getter functions for getting the value of private member of the class.
 * and setter function for setting the value of a private member of the class.
 */
namespace project27_classes_encaptulation_and_exceptions_throwing
{
	class Program
	{
		public static void Main(string[] args)
		{
			Encapsulation_Example pobject = new Encapsulation_Example();
			pobject.SetAge(15);
			pobject.SetName("Ellias Mustellar");
			Console.WriteLine("Name: {0}\nAge: {1}", pobject.GetName(), pobject.GetAge());
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Encapsulation_Example
	{
		//Members: (sometimes called proprieties)
		private int _age; //as good programming habbit the private variables in a function should start with 
		//underscore/underline.
		private string _Name;
		//Setters:
		public void SetAge(int NewAge)
		{
			if(NewAge<=0)
			{
				//An exception is an error message, that occures and terminates the program in case that
				//something goes wrong.
				//Sinthax for throwing exception
				throw new Exception("A person cannot have NULL or NEGATIVE age.");
			}
			_age=NewAge;
		}
		public void SetName(string NewName)
		{
			//string.IsNullOrEmpty (string_name) -> function that checks if a string is null or empty
			if(string.IsNullOrEmpty(NewName))
			{
				throw new Exception("The name cannot be NULL or EMPTY.");
			}
			_Name = NewName;
		}
		
		//Getters:
		public int GetAge()
		{
			return this._age;
		}
		public string GetName()
		{
			return this._Name;
		}
	}
}