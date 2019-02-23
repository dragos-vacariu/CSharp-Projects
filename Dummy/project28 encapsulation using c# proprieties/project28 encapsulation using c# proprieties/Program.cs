/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project28_encapsulation_using_c__proprieties
{
	class Program
	{
		public static void Main(string[] args)
		{
			Encapsulation_Proprieties prop = new Encapsulation_Proprieties();
			//This is the way of setting the variable's value after writing the proprieties:
			prop.Age=15;
			prop.Name="Black";
			//This is the way of getting the variable's value after writing the proprieties:
			Console.WriteLine("Name: {0}\nAge: {1}", prop.Name, prop.Age);
			//the sinthax are identical, for setting and getting the value of a variable, but allthrough
			//the compiler knows exactly how to interpret that.
			
			Console.WriteLine("Enter your email address: ");
			//USING THE AUTO IMPLEMENTED PROPRIETY:
			prop.Email=Convert.ToString(Console.ReadLine());
			Console.WriteLine("Your email is: {0}", prop.Email);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class Encapsulation_Proprieties
	{
		private int _age;
		private string _name;
		
		//Setting the proprieties:
		/*To create a read only proprieties only the "get" field must be present into the propriety, whereas to create
		 a write-only proprity only the "set" field must be present into the propriety.*/
		public int Age 
			//Age is the name of the propriety in this case.
		{
			set //this sinthax replaces the setter function for Age.
			{
				//Using the proprieties the value sent for the variable is stored into this "value" keyword.
				if(value <=0)
				{
					throw new Exception ("The age cannot be NULL or NEGATIVE.");
				}
				//Using this. keyword to reach the class member.
				this._age=value;
			}
			get //this sinthax replaces the getter function for Age.
			{
				return this._age;
			}
		}
		//Similar for this one too.
		public string Name 
			//Name is the name of the propriety in this case.
		{
			set //this replaces the setter function of the Name.
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new Exception ("The name cannot be NULL or EMPTY.");
				}
				this._name=value;
			}
			get //this replaces the getter function of the Name.
			{
				//using this. keyword to reach the member's value
				return this._name;
			}
		}
		
		//AUTO IMPLEMENTED PROPRIETIES IN C# 3.0
		public string Email
		{
			/*In this case the compiler will automatically create a private variable that will corespond to this
			 * field, and to which the user can read or write information using the AUTO IMPLEMENTED propriety.
			 */
			set;
			get;
		}
		/*The purpose of auto implemented proprieties is that to reduce the code, and the time for writing a 
		 * designed propriety when it's not the case, or when an optional field comes up. This are no use
		 * of additional logic for getting or setting the value of a field.
		 */
	}
}