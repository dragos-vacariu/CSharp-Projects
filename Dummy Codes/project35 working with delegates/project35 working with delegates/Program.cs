/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 18:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
/*Delegate allows the flexibility of reusing the code without modifications
 Provides for the programming the way of designing a class that could be use by any company, by their own 
 desire without changing a thing inside the class. So delegate will point to a function that's outside the class
 and the function will keep all the logic for an specific operation. SO if someone wants to change something, they
 wouldn't have to change in the class, but only in the function.
 */
namespace project35_working_with_delegates
{
	//Creating a delegate for a function that return a bool and takes as argument an object of type ExampleClass.
	public delegate bool IsMajor(ExampleClass object_delegate);
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating a list of object of type ExampleClass.
			List <ExampleClass> mylist = new List <ExampleClass> ();
			//Filling the list with some objects:
			mylist.Add(new ExampleClass{Name="Black", Age=22}) ; //adding objects to the list using the object adder sinthax
			mylist.Add(new ExampleClass{Name="Ellias", Age=12});
			mylist.Add(new ExampleClass{Name= "Allan", Age=24});
			//Creating an instance of the delegate IsMajor:
			IsMajor CheckIfMajor = new IsMajor(RootFunction); //the delegate is pointing to the RootFunction();
			//Creating an simple object to can access the PrintMajors() function of the class ExampleClass.
			ExampleClass objectToCallFunction = new ExampleClass();
			//Calling the function;
			objectToCallFunction.PrintMajors(mylist, CheckIfMajor);
			//End of program:
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static bool RootFunction(ExampleClass simple_object)
		{
			//Using ternary operator;
			bool checker=simple_object.Age>=18?true:false;
			return checker;
		}
	}
	public class ExampleClass
	{
		private string _name;
		private int _age;
		//Proprieties:
		public string Name //propriety name
		{
			get { //using this instead of getter
				return this._name;
			}
			set { //using this instead of setter
				this._name=value;
			}
		}
		public int Age //propriety name
		{
			get { //using this instead of getter
				return this._age;
			}
			set { //using this instead of setter
				this._age=value;
			}
		}
		//The implementation of a function that will print the majors.
		public void PrintMajors(List <ExampleClass> simplelist, IsMajor Check_majority)
		{
			foreach (ExampleClass k in simplelist) //put every object of simplelist into k
			{
				if(Check_majority(k)) //if the delegate on the object k is return true.
				{
					Console.WriteLine("Name: {0}, Age: {1} -> is major!", k._name, k._age);
				}
			}
		}
	}
}