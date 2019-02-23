/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 16:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; // using this for lists and collections.

namespace project53_functions_for_lists
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Initialization of a list
			List <People> mylist = new List<People> (2); //a list of 2 elements.
			mylist.Add(new People{Name="Alan", ID=1});
			mylist.Add(new People{Name="Eric", ID=2});
			//If we add one more element the list will grow in size automatically:
			mylist.Add(new People{Name="Jenny", ID=3});
			//To get the number of elements within the list we can use the next property:
			Console.WriteLine("Actuall size of the list: {0}", mylist.Count);
			//Displaying elements using for loop:
			Program.DisplayListElements(mylist); //calling the static function
			//To add an element within a certain index:
			People obj = new People{Name="Danny", ID=4};
			mylist.Insert(2, obj);
			//Displaying the function again:
			Program.DisplayListElements(mylist);
			//To remove an element from a specified index:
			mylist.RemoveAt(2);
			Program.DisplayListElements(mylist);
			//To check if an element exists and to get it's index:
			Console.WriteLine("The element at index: {0}", mylist.IndexOf(obj)); //(-1) if the object is not in the list
			//To check if a list contains a certain element:
			Console.WriteLine("The element obj is in the list: {0}", mylist.Contains(obj));
			//To find an element within a certain condition:
			Console.WriteLine("Is there an element with ID=3: {0}", mylist.Exists(pp => pp.ID==3));
			//End of program:
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Creating a function to display the elements within a list:
		public static void DisplayListElements(List <People> mylist)
		{
			for(int i=0; i<mylist.Count; i++)
			{
				Console.WriteLine("Name: {0}	ID: {1}", mylist[i].Name, mylist[i].ID);
			}
			Console.WriteLine();
		}
	}
	class People
	{
		public string Name {set;get;}
		public int ID {set;get;}
	}
}