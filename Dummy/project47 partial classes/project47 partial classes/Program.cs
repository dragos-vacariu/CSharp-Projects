/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 16:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

/*A partial class its used to separate/split a class into two or more parts, across different files.
 If the part of the class are in different files, those files must be contained in the same assembly (directory of project), otherwise
 the compilation will fail. 
 A partial class can also be used in techniques of splitting an interface into more parts successfully.
 
 IMPORTANT: Without the partial keyword into the class declaration, the compiler will not know the intention of creating a partial class.
 All the parts of a partial class needs to be contained by the same namespace and assembly.
 All the parts must use the partial keyword in their declaration.
 All the parts must use the same access modifier in their declaration.
 If any of the parts is declared as abstract, the entire class will be abstract (even if only a part was declared abstract).
 If any of the parts is declared as sealed, the entire class will be sealed.
 If any of the parts is declared to be inherited from a a class, the entire class will be inherited from that class. IMPORTANT, different
 parts of the partial class cannot specify that they are inherited from different classes. (IN C# MULTIPLE CLASS INHERITANCE IS NOT ALLOWED).
 Different parts of the partial class can specify that they inherits from different interfaces, so after the compilation the partial class
 will be inherited from all the specified interfaces (even if they were specified in different parts of the class).
 The members declared to a part of the partial class are available to all the part of the partial class (available in the entire class).
 */


namespace project47_partial_classes
{
	class Program
	{
		public static void Main(string[] args)
		{
			//A partial class its used like a normal class.
			MyClass obj = new MyClass();
			obj.Age = 16;
			obj.Name = "Ellias";
			obj.PrintInfo();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	//Example of partial class:
	partial class MyClass //the partial keyword must be used for all the parts of the class.
	{
		private string _Name;
		private int _Age;
		public int Age
		{
			get {
				return _Age;
			}
			set
			{
				_Age=value;
			}
		}
		public string Name
		{
			get {
				return _Name;
			}
			set
			{
				_Name=value;
			}
		}
		//THE SECOND PART OF THE CLASS IS IN THE ASSEMBLY DIRECTORY (PROJECT DIRECTORY), WITH THE NAME PartialClassPartTwo, AND
		//CONTAINS A METHOD CALLED PrintInfo().
	}
	
}