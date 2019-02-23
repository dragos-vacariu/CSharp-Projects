/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 20:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project22_static_variables_and_members
{
	class Program
	{
		static int j=5;
		int i=5;
		/*In a class a static member is a member that won't change in time, just as a constant. So it's a member
		 * that won't be duplicated when creating multiple objects of the class. In this case if we'd create 10
		 * objects of the Program class, there will still be ONE and ONLY Main function, because our Main function
		 * is STATIC.
		 * 
		 * In C++ static has other meanings too: Can be used to keep a value inside a variable which has a lifetime 
		*until the program ends. Static variable in c++ can be initialized only once.
		 */
		public static void Main(string[] args)
		{
			Program p = new Program();
			Program p2 = new Program();
			p.StaticVariableFunct(); //static j is initialized with 5, in StaticVariableFunct gets added with 5, so 
			//5+5=10
			p2.StaticVariableFunct(); //as j is static, when created the second object, the value of j = 10, because
			//in the first object j was 10, so now 10+5=15;
			p.InstanceVariableFunct(); //i is not static so i is initialized with 5, in the InstanceVariableFunct gets
			//added by 5, so 5+5=10;
			p2.InstanceVariableFunct(); //the story of i repeats again, because it's not a static variable.
			
			//Calling static and instance variable:
			Console.WriteLine("The J: {0}", Program.j);//a static member can never be invoked using this. keyword
			//they can only be invoked using the CLASS_NAME.VARIABLE_NAME;
			Console.WriteLine("The I: {0}", p.i); //an instance member cannot be refered to with this. keyword
			//if the invokation is done inside a static method. In a static method the instance variables can be 
			//called only by using an instance of the class (p and p2 are objects or instances of the class).
			
			/*STATIC MEMBERS: are called using the name of the class that they belong to.
			 * INSTANCE MEMBERS: are called using the instance or object of the class that they belong to.
			 */
			//STATIC CONSTRUCTORS (of a class) are used to initialized STATIC MEMBERS/FIELDS(variables).
			//STATIC CONSTRUCTORS (of a class) are called only once, even before the INSTANCE CONSTRUCTOR, and before
			//creating an object.
			//STATIC CONSTRUCTORS (of a class) cannot contain access-modifiers.
			//An instance constructor is a constructor that is not static, an instance constructor will be called
			//when an object is created.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public void StaticVariableFunct()
		{
			j+=5;
			Console.WriteLine("The value of static variable is: {0}",j);
		}
		
		public void InstanceVariableFunct()
		{
			i+=5;
			Console.WriteLine("The value of the instance variable is: {0}", i);
		}
	}
}