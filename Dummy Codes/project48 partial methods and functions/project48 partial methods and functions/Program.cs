/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*A partial method or function can be declared ONLY in PARTIAL classes and PARTIAL structs.
 A partial method or function is created using the partial keyword (just like partial classes).
 A partial method declaration consists into 2 parts: the definition(only the signature), and the implementation(these part cannot be done 
at the same time, as in case of normal functions/methods). They may be separated in different parts of a partial class or in the same part.
 The implementation of the partial function is optional. If a partial function is not implemented, at the compilation time, the compiler
 removes the signature of the partial function and all the calls to it.
 Partial methods are private by default, and cannot have access-modifiers and virtual, abstract, override, new, sealed, extern modifiers. 
So a partial function/method can be called only inside the class where it's declared and implemented.
 A partial method's return type needs to be void (a partial function cannot return a value).
 It is a compilation error to include the definition and implementation of a partial class at the same time.
 A partial method can be implemented ONLY once.
 */

namespace project48_partial_methods_and_functions
{
	class Program
	{
		public static void Main(string[] args)
		{
			MyClass classobj = new MyClass(); //creating an object of the partial class.
			classobj.AccessingPartialMethod(); //calling the function that calls the partial function.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	partial class MyClass
	{
		//This is the declaration of the class.
		partial void PrintingAMessage(); //this can be done in any part of the partial class/struct
		
		//This is the implementation of the class.
		partial void PrintingAMessage() //this can be done also in any part of the partial class/struct
		{
			Console.WriteLine("Partial Function Message");
		}
	}
}