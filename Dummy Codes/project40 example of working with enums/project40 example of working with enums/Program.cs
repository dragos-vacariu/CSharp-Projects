/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 21.07.2016
 * Time: 10:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
/*Enums provide readability for the programs. Instead of working with int number for option modes (as it is by 
 default), a enum within its integral number holds a value that specifies the option name.
 An enum values can be customized as follows:
 public enum Names: short //-> in this case the values used for the enum options are of type short.
{
	Mark, Derek, Allan
};
The options for the enum can be initialized with values:
public enum Drinks
{
	Cola = 3;
	Sprite = 7;
};
Enums are strongly types constants -> they cannot be implicitly converted to other types and vice-versa.
 */
 
namespace project40_example_of_working_with_enums
{
	class Program
	{
		public static void Main(string[] args)
		{
			Citizens[] arrayofPeople = new Citizens[3];
			arrayofPeople[0] = new Citizens{Name="Allan", gender=Gender.Male};
			arrayofPeople[1] = new Citizens{Name="Mary", gender=Gender.Female};
			arrayofPeople[2] = new Citizens{Name="Sam", gender=Gender.Unknown};
			//Printing the gender;
			foreach (Citizens k in arrayofPeople)
			{
				Console.WriteLine("Name: {0}	Gender: {1}", k.Name, k.gender);
			}
			Console.WriteLine();
			//If we would be using integers the output would be this:
			foreach(Citizens k in arrayofPeople)
			{
				Console.WriteLine("Name: {0}	Gender: {1}", k.Name, (int)k.gender);
				//So there will be needed a switch statement to provide the name for the options.
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	public enum Gender {Unknown, Male, Female};
	class Citizens
	{
		public string Name { get; set; }
		public Gender gender { get; set; }		
	}
}