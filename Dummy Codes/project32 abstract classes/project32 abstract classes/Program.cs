/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 15:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*An abstract class is similar to an interface, dispite that it can contain variable_members (field members), and
 an abstract class it's acting like a class when it comes to inheritance. An abstract class can have implementation
 for some or even for all its members/field, while the interface cannot. An abstract class can use the (public) 
access modifiers while an interface cannot. An abstract class member is private by default while an interface
member is public by default. An interface can be inherited ONLY from another interface, while an abstract class
can be inherited either from an interface or abstract class. A class can be inherited from multiple interfaces in the
same time whereas a class cannot be inherited from multiple classes.

RULES FOR ABSTRACT CLASSES:
 1.An abstract class cannot be instanciated (an instance of the class cannot be created).
 2.An abstract class can contain abstract members, and the abstract members are not allowed to be implemented in
 that class.
 3.An abstract class can inherit (can have children classes), and every child of the class must provide its
 own implementations for the abstract members of the parent class.
 4.Any class provides single inheritance (the child of the class can have only one parent/base class).
 5.An abstract class can only be used as a base class. SO an abstract class cannot be SEALED.
 6.An abstract class CAN HAVE NO ABSTRACT MEMBERS, so it can provide implementation for all its fields and members.
 7.If a class that's inherited from an abstract class doesn't wish to provide implementation for the parent class
 abstract members, then that class can be also set as abstract.
 */

namespace project32_abstract_classes
{
	class Program: AbsClass //A class can inherit only from a single class. (multiple class inheritance is not allowed)
	{
		public static void Main(string[] args)
		{
			Program p1 = new Program();
			p1.MessageShow();
			p1.Print();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//IN order to provide implementation for an abstract member of the parent class the override keyword 
		//must be used.
		protected override void Print()
		{
			Console.WriteLine("Providing implementation for the parent abstract class member.");
		}
	}
	//Creating an abstract class:
	public abstract class AbsClass
	{
		protected abstract void Print(); //this function is abstract
		public void MessageShow() //this is a normal function
		{
			Console.WriteLine("This is not an abstract member.");
		}
	}
}