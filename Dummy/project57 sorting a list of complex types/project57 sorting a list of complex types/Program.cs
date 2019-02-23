/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 18:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for lists and collections;

/*In order to compare a complex type (object or instance of a class), you need to make that class inherit from IComparable Class, and to 
 override an implementation for CompareTo() function of that class.
 After doing those, the Sort() and Reverse() functions will work on that complex type.*/

namespace project57_sorting_a_list_of_complex_types
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<People> mylist = new List<People>();
			mylist.Add(new People{Name="Michael", Age=11});
			mylist.Add(new People{Name="Jean", Age=21});
			mylist.Add(new People{Name="Jerry", Age=34});
			mylist.Add(new People{Name="Karren", Age=51});
			mylist.Add(new People{Name="Rob", Age=9});
			Console.WriteLine("List before sorting:\n");
			DisplayList(mylist);
			mylist.Sort();
			Console.WriteLine("\nList after sorting:\n");
			DisplayList(mylist);
			mylist.Reverse();
			Console.WriteLine("\nList reverse order:\n");
			DisplayList(mylist);
			Console.WriteLine("\nList sorted by name:\n");
			//Creating a instance of the comparer created class;
			SortByName sorter = new SortByName();
			mylist.Sort(sorter);
			DisplayList(mylist);
			//End of program;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void DisplayList(List<People> mylist)
		{
			foreach(People k in mylist)
			{
				Console.WriteLine("Name: {0}	Age:{1}", k.Name,k.Age);
			}
		}
	}
	class People: IComparable<People>
	{
		public int Age{get;set;}
		public string Name{get;set;}
		public int CompareTo(People other)
		{
			return this.Age.CompareTo(other.Age);
			/* Equivalent method:
			if(this.Age>other.Age)
			{
				return 1;
			}
			else if(this.Age<other.Age)
			{
				return -1;
			}
			else
			{
				return 0;
			}
			*/
		}
	}
	//Creating a sorting class:
	class SortByName: IComparer<People> //the sorting class must be inherited from IComparer<Object_used_for_comparation>
	{
		public int Compare(People a, People b)
		{
			return a.Name.CompareTo(b.Name); //setting the function.
		}
	}
}