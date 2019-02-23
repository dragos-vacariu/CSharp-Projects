/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//The namespace need to be declared in here
using Project20.DeadyOnline; //declaration of the namespace.
using PATA = Project20.DeadyOnline; //Creating a namespace alias called PATA.
//Namespace ALIASES can be used to avoid ambiguity errors. An ambiguity erros is when declaring 2 namespaces which
//may contains some classes or functions with the same name, so when trying to call the function, the compiler
//will not know to which one are you refering to.

//THIS IS AN EXTERNAL CLASS PROJECT
using ProjectA.TeamB; // in order to use this you need to right click on this project and add the ProjectA.TeamB
//as reference to the main project (in this case this is the main project).

namespace project20_namespaces
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating an instance for the Class that's inside the namespace Project20.DeadyOnline
			//A namespace is using much like a path to a file, or a directory(folder).
			Project20.DeadyOnline.FirstClass p = new Project20.DeadyOnline.FirstClass();
			//If the namespace is declared above, an object of the class can be created as follows:
			FirstClass p2 = new FirstClass();
			
			//Calling the function that's inside the namespace below.
			Project20.DeadyOnline.FirstClass.PrintingMethod(); //calling the STATIC function, which needs to be
			PATA.FirstClass.PrintingMethod();//calling the function using the namespace alias PATA.
			//called using the qualify name of the class
			
			//Also the function can be called like this if the namespace is declared above.
			FirstClass.PrintingMethod();
			p.AnotherMessage();//calling the INSTANCE (non-static) function.
			p2.AnotherMessage(); //calling the INSTANCE (non-static function) using the object 2.
			
			//Calling a function from external namespace and class.
			MyClass ms = new MyClass(); //creating an instance of the class.
			ms.PrintName();//the function is INSTANCE function (so it needs to be called with and instance of
			//the class that it belongs to).
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
//Namespaces are used to organize the code/programs, and to avoid name clashes.
//Creating a namespace: (this is internal namespace because it's written into the same file.)
namespace Project20
{
	namespace DeadyOnline
	{
		class FirstClass
		{
			public static void PrintingMethod()
			{
				Console.WriteLine("This is a function from a SELF-CREATED namespace.");
			}
			public void AnotherMessage()
			{
				Console.WriteLine("This function is INSTANCE function.");
			}
		}
	}
}