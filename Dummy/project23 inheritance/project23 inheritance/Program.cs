/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.07.2016
 * Time: 13:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*Inheritance is when a class depends on another, or a class derive from another.
 *Inheritance is used to reduce the code size, and the amount of resources used, allowing the code re-use.
 *Inheritance can also prevent errors, and reduce the time for designing a software.
 */
using inherited_classes; //using the namespace from the other file.

namespace project23_inheritance //the namespace used for this file.
{
	class Program
	{
		public static void Main(string[] args)
		{
			Mates m = new Mates(); //Creating an object with default constructor
			m.DisplayInfo(); //Displaying Info
			Mates Ellias = new Mates("Ellias", "Mustellar", 17, 'A'); //Creating an object with a predefined (overloaded) 
			//constructor
			//DYSPLAYING INFO:
			Ellias.DisplayInfo();
			Ellias.DisplayGrades();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}