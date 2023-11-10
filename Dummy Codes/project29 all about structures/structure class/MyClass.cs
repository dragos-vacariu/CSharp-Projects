/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.07.2016
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace structure_class
{
	/// <summary>
	/// structure class
	/// </summary>
	/*A struct is very similar (almost identical) with a class. A struct can have members, getters and setters for
	 encapsulation or c# proprieties for encapsulation, a struct can have methods, function, constructors (only
	parameter constructors)
	 
	VERY IMPORTANT: As a differences between classes and structs: 
	A struct cannot have a destructor, while a class can have destructor.
	A struct can have only constructors that take arguments (constructors with parameters), while a class can have
	any type of constructors.
	A struct cannot inherit from a class, while a class can inherit from a class.
	Structures and classes cannot inherite from other structures. Structures cannot have children.
	Structures and classes can inherit both from an interface.
	 */
	public struct MyStruct
	{
		//Struct Members:
		private int _age;
		private string _name;
		
		//Proprieties:
		public int Age
		{
			get {
				//this. keyword can also be used for structures, as they're used for classes.
				return this._age;
			}
			set {
				if(value<=0)
				{
					throw new Exception("The age cannot be NULL or NEGATIVE.");
				}
				this._age = value;
			}
		}
		public string Name
		{
			get {
				return this._name;
			}
			set {
				if(string.IsNullOrEmpty(value))
				{
					throw new Exception ("The name cannot be NULL or EMPTY");
				}
				_name = value;
			}
		}
		//Constructor
		public MyStruct(int AGE, string NAME)
		{
			_name=NAME;
			_age=AGE;
		}
		//Methods:
		public void PrintDetails()
		{
			Console.WriteLine("Name: {0}\nAge: {1}", this._name, this._age);
		}
	}
}