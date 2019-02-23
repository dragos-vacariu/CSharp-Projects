/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 20:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project21_classes_and_this_keyword
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Working with the other class:
			Simple_name.FirstClass obj = new Simple_name.FirstClass("Ellias", "Mustellar"); //creating the object
			obj.DisplayName(); //calling the function.
			//Using the pre-defined default constructor:
			Simple_name.FirstClass obj2 = new Simple_name.FirstClass();
			obj2.DisplayName();
			//End of the program.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
//Argument = a value passed as parameter to a function.
//Parameter = a variable that stores a value called argument.

//Creating a namespace:
namespace Simple_name
{
	class FirstClass
	{
		//Class Members:
		string _firstName;
		string _lastname;
		//Creating a constructor:
		//(A CLASS WITHOUT A CONSTRUCTOR, WILL HAVE A DEFAULT CONSTRUCTOR WITH NO ARGUMENTS, OFFERED BY THE 
		//C# COMPILER).
		public FirstClass(string Fname, string Lname) //A constructor can take arguments. The constructor it's
			//automatically called when creating the object.
		{
			//The keyword "this." it's used to refer strictly to a member (sometimes called object) of this class, 
			//so there won't be any confusion, if there are more variables with the same name.
			this._firstName=Fname;
			this._lastname=Lname;
		}
		//To avoid getting a default constructor all you need to do is create a constructor by yourself.
		//to have a default constructor, in case that someone wants to create an object without passing
		//arguments to the real constructor, you can do this:
		public FirstClass(): this("No First Name Provided", "No Last Name Provided")//IN THIS CASE "THIS" WILL BE
			//WRITTEN WITHOUT A "." (POINT)
		//this will now became a default constructor.
		{
		}
		public void DisplayName() //this function is public
		{
			Console.WriteLine("First Name: {0}\nLast Name: {1}", this._firstName, this._lastname);
		}
		//Creating a destructor:
		~FirstClass() //A destructor cannot take arguments. SO it cannot have parameters.
		{
			//All the cleaning code needs to be in here.
			//The destructor is automatically executed when the program ends. So it doesn't need to be called
			//during the runtime of the program.
		}
	}
}