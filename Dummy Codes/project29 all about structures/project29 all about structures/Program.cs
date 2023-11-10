/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using structure_class;

/*DIFFERENCES BETWEEN CLASSES AND STRUCTS:
 * Classes are reference type, while structs are value type.
 * Structs are stored on the stack memory, while classes are stored on the heap memory.
 * Value types (as in case of structs) hold their value in memory where they are declared, while reference types
 * (as in case of classes) hold a reference to an object stored in memory.
 * Value types (as in case of structs) are destroyed and lose their value after their scope is lost, whereas
 * reference types (as in case of classes) gets their reference destroyed after completing their scope, and
 * the value (the place in memory) is cleaned after the program ends, in a process called garbage collector.
 * When copying a struct into another struct, a new copy of the struct is created, so one change into a struct will
 * not affect the other. While when copying a class into another class, a reference to the class is created, and
 * any change that's made to a class si made to the other too.
 * 
 * When thinking of a struct, just imagine an integer variable: int i = 10, which will gets destroyed when the
 * function in which is declared will end.
 * When thinking of a class, just imagine a pointer to an integer: int * i = 10, when the function in which is
 * declared is destroyed only the reference variable is lost (in this case i), but the value 10 is still stored
 * somewhere in memory (on the heap).
 */

namespace project29_all_about_structures
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating an instance/object of the struct:
			//Using the pre-defined constructor
			MyStruct struct1= new MyStruct(21, "Bob");
			struct1.PrintDetails();
			//Using the default constructor
			MyStruct struct2 = new MyStruct();
			struct2.Age=32; //setting the member
			struct2.Name="Darren"; //setting the member
			struct2.PrintDetails();
			//Using the object initializer sinthax: (this was introduced in c# 3.0)
			MyStruct struct3 = new MyStruct{ Name = "Black", Age=23 };
			struct3.PrintDetails(); 
			
			//Value type VS Reference types (JUST EXAMPLE):
			//-for value types (structs):
			Console.WriteLine("\nFor value types (STRUCTS):");
			MyStruct s1 = new MyStruct(11, "Allen");
			MyStruct s2 = s1;
			Console.WriteLine("s1.Name: {0}",s1.Name);
			Console.WriteLine("s2.Name: {0}",s2.Name);
			s1.Name="Jake";
			Console.WriteLine("After modifying s2:");
			Console.WriteLine("s1.Name: {0}",s1.Name);
			Console.WriteLine("s2.Name: {0}",s2.Name);
			//-for reference types (classes):
			Console.WriteLine("\nFor reference types (CLASSES):");
			Test t1 = new Test ();
			t1.Name = "TestClass";
			Console.WriteLine("t1.Name = {0}", t1.Name);
			Test t2 = t1;
			Console.WriteLine("t2.Name = {0}", t2.Name);
			t2.Name = "Simple name";
			Console.WriteLine("After modifying t2: ");
			Console.WriteLine("t1.Name = {0}", t1.Name);
			Console.WriteLine("t2.Name = {0}", t2.Name);
			
			//END OF PROGRAM:
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Test //this class is created just to exemplify the difference between value types and reference types.
	{
		private string _name;
		public string Name {
			get {
				return this._name;
			}
			set {
				_name = value;
			}
		}
	}
}
