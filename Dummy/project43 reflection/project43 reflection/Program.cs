/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 15:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection; //using this namespace for reflection

/*
 Reflection is used to obtain information about the software code (the metadata part of the code), while it is in runtime. 
Also reflection is the ability of inspecting the code's metadata in runtime. The metadata part of a code, contain the information about
 the fields, methods, proprieties, variable, etc, used inside the software.*/
 
/*In C# every object is direclty or indirectly inherited from System.Object class, so every type and object will have the functionality of:
 getType(), ToString() etc*/

namespace project43_reflection
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Getting the type:
			Type T = Type.GetType("project43_reflection.ExampleClass"); //T gets the type of the project43_reflection.ExampleClass.
			//Equivalent methods to get the type: 
			//Type T = typeof (ExampleClass);
			//ExampleClass ec = new ExampleClass();
			//Type T = ec.GetType();
			
			//Getting the properties:
			PropertyInfo [] proprietiesFound = T.GetProperties(); //T.GetProprieties returns an array of type PropertyInfo, containing all
			//the information about the proprieties of the class.
			foreach(PropertyInfo k in proprietiesFound)
			{
				Console.WriteLine("Property Name: {0}	Property type: {1}", k.Name, k.PropertyType); //printing the proprieties of the
				//class ExampleClass.
			}
			Console.WriteLine();	
			//Getting the methods:
			MethodInfo[] methodsFound = T.GetMethods();
			foreach(MethodInfo k in methodsFound)
			{
				Console.WriteLine("Method Name: {0}		Method return type: {1}", k.Name, k.ReturnType);
			}
			Console.WriteLine();
			//Getting members:
			MemberInfo [] membersFound = T.GetMembers();
			foreach(MemberInfo k in membersFound)
			{
				Console.WriteLine("Member Name: {0}		Member type: {1}", k.Name,  k.MemberType);
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class ExampleClass
	{
		//Variables:
		private int _age;
		private string _name;
		//Properties:
		public string Name 
		{
			get{
				return this._name;
			}
			set{
				this._name=value;
			}
		}
		public int Age
		{
			get{
				return this._age;
			}
			set{
				this._age=value;
			}
		}
		//Methods:
		public void Print()
		{
			Console.WriteLine("Name: {0}	Age: {1}", this._name, this._age);
		}
	}
}