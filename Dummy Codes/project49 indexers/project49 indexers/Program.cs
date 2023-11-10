/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for lists.
using System.Linq; //using this for FirstOrDefault function for lists.

/*An indexer is used to get and change the information within a class by using a given criterium (property or field).
 An indexer can be created similarily as a property can be created.
 Overloading an indexer is similarily to overloading a function or a constructor. An indexer can also be overloaded by changing the type
or kind of the parameter, and the number of parameters.
 */

namespace project49_indexers
{
	class Program
	{
		public static void Main(string[] args)
		{
			City newcityOBJ = new City();
			//Getting value within the indexer
			Console.WriteLine("The name of the Citizen with Id=3 is: {0}", newcityOBJ[3]);
			//Changing value within the indexer
			newcityOBJ[3]="Sammy";
			Console.WriteLine("The NEW name of the Citizen with Id=3 is: {0}", newcityOBJ[3]);
			//USING THE OVERLOADED INDEXER:
			Console.WriteLine("The gender of the Citizen with Name=Mike is: {0}", newcityOBJ["Mike"]);
			newcityOBJ["Mike"] = "Female";
			Console.WriteLine("The NEW gender of the Citizen with Name=Mike is: {0}", newcityOBJ["Mike"]);
			//End of program.
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	//Creating a class for our item.
	public class Citizens
	{
		public string Name {get; set;}
		public int Age {get; set;}
		public string Gender {get; set;}
		public int ID {get; set;}
	}
	//Creating the class that we'll use.
	class City
	{
		//Creating a list for our items.
		List <Citizens> People = new List<Citizens>();
		//Initializing the list in our constructor.
		public City()
		{
			People.Add(new Citizens{Name = "Adam", Age = 21, ID = 1, Gender="Male"});
			People.Add(new Citizens{Name = "Mike", Age = 33, ID = 2, Gender="Male"});
			People.Add(new Citizens{Name = "Jean", Age = 11, ID = 3, Gender="Female"});
			People.Add(new Citizens{Name = "Eric", Age = 12, ID = 4, Gender="Male"});
		}
		//Creating the indexer.
		public string this[int ID] //to create an indexer you need to use this keyword.
		//AN indexer can be created similarily to the property of a field.
		{
			get //an indexer has also get and set accesors
			{
				return People.FirstOrDefault(k => k.ID == ID).Name; //Using FirstOrDefault Function.
				//k is a variable that will store each object in the list while checking if k.ID == ID; similar as in the method below
				
				/* Equivalent Method:
				foreach (Citizens k in People)
				{
					if(k.ID==ID)
					{
						return k.Name;
					}
				}
				
				return ""; */
			}
			set //an indexer has also get and set accesors
			{
				People.FirstOrDefault(k => k.ID == ID).Name = value; //Using FirstOrDefault function.
				//k is a variable that will store each object in the list while checking if k.ID == ID; similar as in the method belo
				
				/* Equivalent Method:
				foreach (Citizens k in People)
				{
					if(k.ID==ID)
					{
						k.Name = value;
					}
				}
				*/
			}
		}	
		public string this[string Name]
		{
			get
			{
				return People.FirstOrDefault(k => k.Name == Name).Gender;
			}
			set
			{
				People.FirstOrDefault(k => k.Name == Name).Gender = value; 
			}
		}
	}
}