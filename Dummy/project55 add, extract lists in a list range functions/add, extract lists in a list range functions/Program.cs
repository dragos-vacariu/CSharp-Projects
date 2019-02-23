/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for lists and collections

namespace project55_add_more_lists_to_a_list
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating the Lists:
			List <People> MyCity = new List<People> (1);
			MyCity.Add(new People {Name="Jean", City="L.A"});
			MyCity.Add(new People {Name="Sean", City="L.A"});
			List <People> OtherCity = new List<People>(1);
			OtherCity.Add(new People {Name="Ben", City="N.Y"});
			OtherCity.Add(new People {Name="Jim", City="N.Y"});
			List <People> TotalPeople = new List<People> (1);
			//Using AddRange() function to add a list into another.
			TotalPeople.AddRange(MyCity);
			TotalPeople.AddRange(OtherCity);
			//Displaying the content:
			foreach(People k in TotalPeople)
			{
				Console.WriteLine("Name: {0}	City: {1}", k.Name,k.City);
			}
			//Getting list from list:
			List<People> NewList = TotalPeople.GetRange(1,3);
			Console.WriteLine("\nExtracting list from list:\n");
			foreach(People k in NewList)
			{
				Console.WriteLine("Name: {0}	City: {1}", k.Name,k.City);
			}
			//Add list within a certain range:
			NewList.InsertRange(1,MyCity);
			Console.WriteLine("\nInsert list within range:\n");
			foreach(People k in NewList)
			{
				Console.WriteLine("Name: {0}	City: {1}", k.Name,k.City);
			}
			//Remove list within a certain range:
			NewList.RemoveRange(2,2);
			Console.WriteLine("\nRemove list within range:\n");
			foreach(People k in NewList)
			{
				Console.WriteLine("Name: {0}	City: {1}", k.Name,k.City);
			}
			//Using RemoveAll() function
			NewList.RemoveAll(pp => pp.City=="N.Y"); //removes all the items within a list that respects the lambda condition:
			Console.WriteLine("\nRemoveAll function:\n");
			foreach(People k in NewList)
			{
				Console.WriteLine("Name: {0}	City: {1}", k.Name,k.City);
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class People
	{
		public string Name {set;get;}
		public string City{set;get;}
	}
}