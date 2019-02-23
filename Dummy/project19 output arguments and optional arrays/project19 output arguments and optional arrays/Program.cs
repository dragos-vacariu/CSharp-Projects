/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*The keyword params it's used only for arays.*/

namespace project19_output_parameters_and_arguments
{
	class Program
	{
		public static void Main(string[] args)
		{
			int Sum, Product=0;
			int [] myarr = new int[] {1,2,3,4,5};
			Program p = new Program();
			p.Calculate(10, 20, out Sum, out Product); //Important not to forget to use the out keyword before
			//the variable_name when calling a function with output parameters.
			Console.WriteLine("Sum={0}\nProduct={1}", Sum, Product);
			
			//Calling a function with optional parameters.
			p.OptionalParams(); //the function can be called ignoring the optional argument/parameter.
			p.OptionalParams(myarr); // the function can be called with an matching parameter.
			p.OptionalParams(10,20,30); // also the function can be called like this. Passing numbers that can be
			//stored into the array.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Function with output arguments. To have output arguments/parameters, you just need to use the out keyword.
		//then the variable_type, and the name of the variable.
		public void Calculate(int numb1, int numb2, out int Sum, out int Product)
		{
			Sum=numb1+numb2;
			Product=numb1*numb2;
		}
		//Functions with optional parameters/arguments. To include a optional parameter or argument into a
		//function or method, you need to use the params keyword before the variable_type. A params argument 
		//need to be declared as the last argument into the function declaration, (just like in C++). There can
		//be only 1 (maximum 1) optional parameter/argument inside a function/method.
		//Using params you can add only arrays.
		public void OptionalParams(params int [] array)
		{
			Console.WriteLine("There are {0} elements in the array.", array.Length);
			foreach(int k in array)
			{
				Console.Write("{0} ", k);
			}
			Console.WriteLine("");
		}
	}
}