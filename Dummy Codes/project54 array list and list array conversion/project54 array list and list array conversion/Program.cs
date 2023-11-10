/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 16:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this namespace for lists and collections;
using System.Linq; //using this for ToList() and ToArray() conversion functions/methods. 

//Array and lists can be converted to each other almost in the same way using ToList() and ToArray functions, from System.Linq namespace;
namespace project54_array_list_and_list_array_conversion
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Array to list conversion:
			People [] myarray = new People[3];
			myarray[0]=new People{Name="Brian", ID=1};
			myarray[1]=new People{Name="Ted", ID=2};
			myarray[2]=new People{Name="Sam", ID=3};
			List <People> convertedlist=myarray.ToList();
			Console.WriteLine("Array to list conversion:\n");
			foreach(People k in convertedlist)
			{
				Console.WriteLine("Name: {0}	ID: {1}", k.Name,k.ID);
			}
			//List to array conversion:
			List<People> mylist = new List<People>(1);
			mylist.Add(new People{Name="Mike", ID=4});
			mylist.Add(new People{Name="Elvira", ID=5});
			mylist.Add(new People{Name="Jim", ID=6});
			Console.WriteLine("\nList to array conversion\n");
			People[]convertedarray=mylist.ToArray();
			foreach(People k in convertedarray)
			{
				Console.WriteLine("Name: {0}	ID: {1}", k.Name,k.ID);
			}
			//End of program;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class People
	{
		public string Name {set;get;}
		public int ID {set;get;}
	}
}