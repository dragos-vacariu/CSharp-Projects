/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project25_polymorphism
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*The idea of polymorphism is creating an array of type parent class, to which you can assign
			 any object of type child classes.*/
			Parent [] objarray = new Parent[4];
			objarray[0]=new Parent();
			objarray[1]=new Child1();
			objarray[2]=new Child2();
			objarray[3]=new Child3();
			foreach(Parent k in objarray)
			{
				k.DisplayInfo(); //each child has the proprieties of the parent class
				
				/*To see the information of each child class we could make a function which will hide the parent
				 * class function, and contain the updated information of the child class. But a better way doing
				 * that is marking the parent class you'd wish to hide with virtual keyword, which will allow
				 * every child class overide the method by their own needs.
				 */
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Parent
	{
		protected string FirstName, LastName;
		public Parent()
		{
			FirstName="FN";
			LastName="LN";
		}
		public virtual void DisplayInfo()
			//The virtual keyword will make this function overidable for each child class.
		{
			Console.WriteLine("This is parent class");
		}
	}
	class Child1:Parent
	{
		//This is the sinthax: for overriding (overwriting) a function.
		public override void DisplayInfo()
		{
			Console.WriteLine("This is a child 1 class.");
		}
	}
	class Child2:Parent
	{
		//This is the sinthax: for overriding (overwriting) a function.
		public override void DisplayInfo()
		{
			Console.WriteLine("This is a child 2 class.");
		}
	}
	class Child3:Parent
	{
		//This is the sinthax: for overriding (overwriting) a function.
		public override void DisplayInfo()
		{
			Console.WriteLine("This is a child 3 class.");
		}
	}
}