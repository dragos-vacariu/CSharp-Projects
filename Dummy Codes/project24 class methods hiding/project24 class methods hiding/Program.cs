/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 14:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

/*Methods to get the info from a hidden function:
 * 1.Type Casting the object of the child class into the parent class type.
 * 2.Calling the parent class hidden function into a child class function with base.function_name.
 * 3.Creating a parent class object with reference to child class.
 */

namespace project24_class_methods_hiding
{
	class Program
	{
		public static void Main(string[] args)
		{
			ChildClass childus = new ChildClass();
			childus.DisplayInfo();//this is child class DisplayInfo() function;
			childus.DisplayInfoParent();//this is parent class DisplayInfo() function;
			
			//OTHER WAY TO GET THE INFO FROM A HIDDEN METHOD/FUNCTION IS TO USE THE TYPE CAST OPERATOR TO THE 
			//OBJECT CREATED FROM THE DERIVED CLASS OR CHILD CLASS.
			((ParentClass)childus).DisplayInfo(); //this is also parent class DisplayInfo() function.
			
			//OTHER	 WAY OF GETTING INFOR FROM A HIDDEN METHOD/FUNCTION, BY CREATING AN OBJECT OF THE
			//PARENT CLASS WITH REFERENCE TO THE CHILD CLASS.
			ParentClass parchil=new ChildClass();
			parchil.DisplayInfo(); //this is also parent class DisplayInfo() function.
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class ParentClass
	{
		protected string FirstName; //this member can be accesed by the child class
		string LastName; //this member is inaccesible from the child class because it's not protected.
		public ParentClass(int JustAnArgument)
		{
			FirstName = "Ellias";
			LastName = "Mustellar";
		}
		public void DisplayInfo()
		{
			Console.WriteLine("Info of ParentClass: \nFirstName: {0}\nLastName: {1}\n", FirstName, LastName);
		}
	}
	class ChildClass:ParentClass
	{
		int age;
		//If the ParentClass has a constructor that takes argument then the ChildClass is obliged to have 
		//a constructor too:
		public ChildClass():base(12)
		{
			age=22;
		}
		/*THIS FUNCTION HAS THE SAME NAME AS THE FUNCTION FROM THE PARENTCLASS, SO THIS FUNCTION WILL
		 * KEEP HIDING THE FUNCTION FROM THE PARENTCLASS, TO HIDE A FUNCTION INTENTIONAL YOU JUST NEED
		 * TO USE THE new KEYWORD IN FRONT OF THE FUNCTION. OTHERWISE A WARNING WILL OCCURE (the program
		 * will still compile an run fine.)
		 */
		public new void DisplayInfo() // the new keyword is to signify that the function hides another 
			//function intentional.
		{
			Console.WriteLine("Info of ChildClass: \nFirstName: {0}\nAge: {1}\n", FirstName, age);
		}
		//One way to get back the hiden function:
		public void DisplayInfoParent()
		{
			base.DisplayInfo(); //this is the ParentClass.DisplayInfo() function.
			//One way to call a parent class inside a child class is to use base.function_name();
			//base is a keyword that refers only to the parent class
			//this is a keyword that refers only to the class you're working to.
		}
	}
}