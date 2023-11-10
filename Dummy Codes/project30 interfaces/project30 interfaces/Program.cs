/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

/*An interface is mostly like a class but with some differences:
 1.An interface cannot have field members/variable members (can have only functions/methods, delegates, events or
proprieties).
 2.An interface cannot contain implementations for the functions/methods(an implementation of a function/method
is the code between the brackets).
 3.An interface has public fields set by default, so inside an interface you cannot use the public acces-modifier
for its members.
 4.A class CAN inherit from an interface. BUT with the condition of providing the implementation for all the
 interface function/method members.
 5.When a class provides implementation of an interface function member, it also needs to make the member function
 public. (The public access modifier must be used.)
 6.A class or struct can inherit from MORE interfaces in the same time. Whereas a class or struct cannot inherit from
 more then one class.
 7.An interface cannot be instanciated (an instance, object of the interface cannot be created), because doing this
 it would mean that you would be able to call a function from the interface, and the interface cannot contain
 implemented members.
 */

namespace project30_interfaces
{
	//Creating an interface:
	public interface Ifirst_interface //an interface name usually starts with I (capital i).
	{
		//int age; -> an interface cannot have such fields (variable fields).
		//public void Print(); -> an interface cannot contain public access modifier.
		void Print(); //this is a function of the interface.
	}
	public interface Isecond_interface : Ithird_interface
	{
		void Print2();
	}
	public interface Ithird_interface
	{
		void Print3();
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Inherited_from_interface Iobject = new Inherited_from_interface();
			Iobject.Print();
			Iobject.Print3(); //calling the grandpa's function.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Inherited_from_interface : Ifirst_interface, Isecond_interface
	{
		/*A class that inherits from an interface HAS to provide implementations for all the interface methods
		 * members.
		 */
		public void Print() //providing implementation for the interface function.
		{
			/*IMPORTANT: when providing implementation for an interface function/method member you have
			 * to specify it to be public. (YOU need to use the public access modifier.)
			 IF A CLASS inherits from multiple interfaces,  then the class has to provide implementation for all
			 the interface members.
			 IF A CLASS inherits from an interface which inherits from another interface, then the class has to
			 provide implementation for both the parent interface and grandparent interface as well.
			 */
			Console.WriteLine("Class inherited from an interface.");
		}
		public void Print2() //A method can be implemented like this. (The brackets can be empty.)
		{
			//By implementing a function inherited from an interface, you have to assure that the function
			//is public, and there exists the brackets (where the implementation should be made).
		}
		public void Print3() //this function is inherited from an interface which inherits from another interface.
		{
			Console.WriteLine("This is the grandpa's function!");
		}
	}
}