/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*Internal access modifiers - allows the usage of class, member or type, only to the others members/types that are
 within the same assembly.
 The assembly is the solution file generated after the compilation of the project. An assembly can be think of as the Directory of the 
project, so internal makes the file available for the files inside the same project/folder. So if there are 2 files that generates the same 
assembly, then the two files can use internal access modifier to access the files of one to another.

IMPORTANT: A referenced project does is not in the same assembly, so the internal access modifier does not work for those.
 
 Protected internal access modified is mixage between the internal and protected access modifiers, and make a member/type available inside
 an assembly and to any class or member that derives (from inheritance), from a class or member that's inside that assembly, (or to derive a 
class that derives from a class that's inside the assembly).
 */

namespace project41_internal_and_protected_internal_access_modifiers
{
	class Program : Other_Assembly.ProtectedInternal_Member //this class will derive from the class that contains the
		//protected internal PrintMethod() function.
	{
		public static void Main(string[] args)
		{
			//Creating an object/instance of the class.
			MyClass obj = new MyClass();
			//Calling the function.
			obj.SimpleMethod();
			obj.GetPrintMethod();
			Program soft = new Program();
			soft.PrintMethod(); //the base class protected internal function is available only here, in its child class.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	public class MyClass : Other_Assembly.ProtectedInternal_Member //class within the same assembly.
		//MyClass also is inherited from PritectedInternal_Member which contains the protected internal PrintMethod() function.
	{
		internal void SimpleMethod()
		{
			Console.WriteLine("Internal public access modifier allows access ONLY within the same assembly!");
		}
		public void GetPrintMethod() //this function will be public and have the functionality of the PrintMethod().
		{
			//the base class(parent class) function is available only here.
			base.PrintMethod(); //calling the protected internal method.
		}
	}
}