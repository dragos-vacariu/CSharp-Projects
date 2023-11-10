/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project26_methods_and_functions_overloading
{
	class Program
	{
		public static void Main(string[] args)
		{
			int outsider;
			Program p = new Program();
			p.Add(10,12);
			p.Add(1,102,34);
			p.Add(0.2f,3.3f);
			p.Add(1,33, out outsider);
			Console.WriteLine("Func4 Result: {0}", outsider);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		/*A function or method can be overloaded using different number of parameters, different types of 
		parameters or different kind of parameters.
		Kinds of parameters are: input parameters, output parameters, reference parameters
		Types of parameters are: float, int, double, char, etc...
		Overloading means that you can have multiple functions with the same name, but respecting at least one of
		the criteria above (also it can respect all of the criteria above). This means that the signature of the
		overloaded function must be different from the primary function.
		Signature consist in number, type and kind of parameters, and also in the code inside the brackets. But
		a signature does not consist in the return type of the function, the access modifier of the function, or
		the optional parameters (params) of the function.
		So a function CANNOT be overloaded ONLY by using different return types, access modifiers, or optional
		params, there must be respected the criteria above.
		
		Examples:*/
		public void Add(int numb1, int numb2)
		{
			Console.WriteLine("Func1\nThe Sum: {0}\n", numb1+numb2);
		}
		public void Add(int numb1, int numb2, int numb3) //method overloaded
		{
			Console.WriteLine("Func2\nThe Sum: {0}\n", numb1+numb2+numb3);
		}
		public void Add(float numb1, float numb2) //method overloaded
		{
			Console.WriteLine("Func3\nThe Sum: {0}\n", numb1+numb2);
		}
		public void Add (int numb1, int numb2, out int sum) //method overloaded
		{
			sum=numb1+numb2;
		}
	}
}