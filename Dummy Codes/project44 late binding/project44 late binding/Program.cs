/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 17:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;

/*Late binding is a technique of calling function within the assembly, in runtime, without having a declaration of it, during the compilation.
 Late binding is complicated, and it not preferred to be used. Also late binding has performace issues, and one late binding error cannot be
 handled. So that's why early binding its used in 99% of cases.
 Late binding it's used only when working with an object that is not available at the compile time.
 
 Early binding consists in normal programming when a class it's and needs to be available at the compile time.*/
namespace project44_late_binding
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating an instance of this Assembly:
			Assembly myassembly = Assembly.GetExecutingAssembly(); //my assembly is of type executing assembly
			//Providing information about the class
			Type MyClassType = myassembly.GetType("project44_late_binding.ExClass"); //GetType("namespace.class");
			//Creating an object to store an instance of MyClassType.
			object instance = Activator.CreateInstance(MyClassType);
			//Getting the information about the method that gonna be invoked.
			MethodInfo getPrintMethodInfo = MyClassType.GetMethod("PrintMethod");
			//This is an object that contains the arguments for the function (if the function has no arguments this step will be skipped).
			string [] arguments = new string[2]; //any type is derived from the object class. So a string can be treated as an object.
			//Initializing the values.
			arguments[0] = "Deady";
			arguments[1] = "Online";
			//Calling the function:
			getPrintMethodInfo.Invoke(instance, arguments);// the invoke method takes 2 parameters (an instance of the class, an object
			//that contains the parameters).
			//AT THIS TIME THE PROGRAM WILL COMPILE EVEN IF THERE IS NO CLASS CALLED ExClass BUT IF THERE IS NO CLASS, WHEN TRYING TO
			//CALL THE FUNCTION WILL RUNTIME AN EXCEPTION WILL OCCURE.
			
			//if the function to be called has a return type (so a value must be stored) it can be done as follows:
			//string value=(string)getPrintMethodInfo.Invoke(instance, arguments);
			//where the invoked function must be type casted to the original function's return type, to may be stored into a variable
			//of the same type.
			
			//END OF PROGRAM.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class ExClass
	{
		public void PrintMethod(string fname, string lname)
		{
			Console.WriteLine("Function called by late binding");
			Console.WriteLine("Arguments passed in: {0}, {1}", fname, lname);
		}
	}
}