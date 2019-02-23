/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 19:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; // using this for lists and collections;

namespace project58_sorting_a_list_of_complex_types_with_delegates
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
			//Creating an instance of the Comparison delegate from System.Colections.Generic namespace.
			Comparison<People> comparer = new Comparison<People>(ComparePeople);
			Console.WriteLine("Before sorting:\n");
			DisplayList(mylist);
			Console.WriteLine("\nAfter sorting:\n");
			mylist.Sort(comparer);
			DisplayList(mylist);
			//The second method is by using only 1 line of code. instead of creating delegate instance, and a comparison function etc.
			//mylist.Sort(delegate(People a, People b){return a.Age.CompareTo(b.Age);}); //this line creates a delegate an a function;
			//The third method by using lambda expresion:
			//mylist.Sort((x,y)=>x.Age.CompareTo(y.Age)); //this works as well.
			
			//End of program:
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
		//The Comparison function passed on to the delegate:
		public static int ComparePeople(People a, People b)
		{
			return a.Age.CompareTo(b.Age);
		}
	}
	class People: IComparable<People>
	{
		public int Age{get;set;}
		public string Name{get;set;}
		//This function can also be used to sort the list.
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
}