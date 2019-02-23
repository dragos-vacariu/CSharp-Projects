/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 15:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project33_multiple_class_inheritance_using_interfaces
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating the instance of the class.
			AB_Functionality newAB = new AB_Functionality();
			//Calling the functions.
			newAB.MessageShow();
			newAB.print();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	interface A1
	{
		void print();
	}
	interface A2
	{
		void MessageShow();
	}
	class A:A1
	{
		int _Age = 12;
		public void print()
		{
			Console.WriteLine("The age from class A: {0}", _Age);
		}
	}
	class B:A2
	{
		string _Message = "Message from class B.";
		public void MessageShow()
		{
			Console.WriteLine("The message is: {0}", _Message);
		}
	}
	//NOW to provide the functionality of those 2 classes inside a single class we can do:
	class AB_Functionality:A1,A2 //this is inherited from 2 interfaces
	{
		A classA = new A(); //creating an instance of class A.
		B classB = new B(); //creating an instance of class B.
		public void print() //provinding implementation for the interface member.
		{
			classA.print(); //getting the information from class A
		}
		public void MessageShow() //providing implemenation for the interface member.
		{
			classB.MessageShow(); // getting the information from class B.
		}
	}
	
}