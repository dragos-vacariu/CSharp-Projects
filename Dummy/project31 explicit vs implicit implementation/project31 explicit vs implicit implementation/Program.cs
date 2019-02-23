/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project30_explicit_vs_implicit_implementation
{
	interface I1
	{
		void Print(); //when there are 2 interfaces with identical function, which inherits into the same child
		//the explicit implementation must be used to avoid ambiguity.
	}
	interface I2
	{
		void Print();
	}
	interface I3
	{
		void MessageShow();
	}
	interface I4
	{
		void MessageShow();
	}
	class Program: I1,I2,I3,I4
	{
		public static void Main(string[] args)
		{
			Program soft = new Program(); //soft is reference variable for an object type Program stored in heap.
			soft.Print(); //calling the implicit implemented function
			
			//By TYPE CASTING - calling the explicit implemented functions.
			((I3)soft).MessageShow(); //calling the explicit implemented function
			((I4)soft).MessageShow(); //calling the explicit implemented function
			
			//By OBJECT REFERENCE - calling the explicit implemented functions.
			I3 explicit1 = new Program();
			I4 explicit2 = new Program();
			explicit1.MessageShow();
			explicit2.MessageShow();
			//END OF PROGRAM;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//This is implicit implementation, the compilation and the runtime is fine, dispite that there is
		//a simple implementation for the both functions.
		public void Print()
		{
			Console.WriteLine("Implicit Implemetation!");
		}
		//Explicit Implementation:
		void I3.MessageShow() //when explicitly implementing a function the access modifiers are not allowed
		{
			Console.WriteLine("This is I3 function!");
		}
		void I4.MessageShow() //when explicitly implementing a function the access modifiers are not allowed
		{
			Console.WriteLine("This is I4 function!");
		}
	}
}