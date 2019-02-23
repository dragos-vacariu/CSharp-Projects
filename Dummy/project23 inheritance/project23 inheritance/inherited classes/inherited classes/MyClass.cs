/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

/*In C# for an inherited class can be only one parent class (only single class inheritance is allowed).
 IN CASE OF INHERITED CLASSES: the parent class constructor gets automatically executed before the child class 
constructor if the parent class constructor has no arguments.
Otherwise if the parent class has a constructors with multiple arguments/parameters it must be specified
at the child class constructor declaration a sinthax:
	:base()
and specify the arguments of the constructor that you want to be executed inside the pharanteses.
 
 IMPORTANT: To prevent a class of having children (inheritance), you can use the sealed keyword.
 A sealed class cannot have children (cannot be base class).
 */
namespace inherited_classes
{
	//These are called XML Comments:
	/// <summary>
	/// Inherited Classes
	/// </summary>
	//This is the parent class.
	public class MyClass
	{
		protected string FirstName;
		protected string LastName;
		protected uint ?age;
		protected MyClass(string FSS)
		{
			Console.WriteLine(FSS);
		}
		public void DisplayInfo()
		{
			Console.WriteLine("Name: {0} {1}",FirstName, LastName);
			if(age==null)
			{
				Console.WriteLine("Age: No Age Provided");
			}
			else
			{
				Console.WriteLine("Age: {0}", age);
			}
		}
	}
	//This is the inherited class.
	public class Mates:MyClass
	{
		char Grades;
		//THIS IS DEFAULT CONSTRUCTOR
		public Mates(): base("CHILD CLASS CONTROLS THE PARENTS CLASS") //this needs to be public.
			//AS YOU SEE THE :base () sinthax appears here too.
		{
			FirstName="No First Name Provided";
			LastName="No Last Name Provided";
			age = null;
		}
		//THIS IS OVERLOADED CONSTRUCTOR
		public Mates(string FS, string LS, uint AGE_m, char GRD) : base("CHILD CLASS CONTROLS THE PARENTS CLASS")
			//the constructor needs to be public
			//:base () -> it's used to explicitely specify which constructor should be used for the parent class
			//THE SINTHAX must be used for each constructor of the child class.
			//if the parent class constructor takes no arguments, then the sinthax is optional.
		{
			FirstName=FS;
			LastName=LS;
			age=AGE_m;
			Grades=GRD;
		}
		public void DisplayGrades()
		{
			///<summary>Displays the grades of the objects in this class.</summary>
			Console.WriteLine("Grade: {0}", Grades);
		}
	}
}