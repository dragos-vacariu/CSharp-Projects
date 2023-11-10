/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 14:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for lists and dictionaries
using System.Linq; // using this for the ToDictionary function;

//Using Extensions to convert arrays and lists to dictionaries:
/*An array and a list can be converted into a dictionary by using the exactly the same sinthax. To convert an list or array to
 dictionary you need only to use the extension function called ToDictionary() which is preset in System.Linq
 Remember if your are working with collections as lists and dictionaries you need to include the namespace System.Collections.Generic*/
namespace project52_converting_arrays_to_dictionaries
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Creating the array:
			Console.WriteLine("Array To Dictionary!\n");
			People [] myarray = new People[3];
			myarray[0]=new People {Age=22, Name="Mark", Gender='M'};
			myarray[1]=new People {Age=11, Name="Aney", Gender='F'};
			myarray[2]=new People {Age=33, Name="Adam", Gender='M'};
			//Transforming the array into a dictionary:
			Dictionary <int, People> mydictionary = myarray.ToDictionary(pp => pp.Age, pp => pp); // in this case pp is called predicator
			//Using the dictionary:
			foreach(var k in mydictionary.Values)
			{
				Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}", k.Name, k.Age, k.Gender);
			}
			Console.WriteLine("\nList To Dictionary!\n");
			//Creating the list:
			List <People> mylist = new List<People>();
			mylist.Add(new People {Age=24, Name="Hank", Gender='M'});
			mylist.Add(new People {Age=18, Name="Jennifer", Gender='F'});
			mylist.Add(new People {Age=11, Name="Derek", Gender='M'});
			//Transforming the list into a dictionary:
			Dictionary <int, People> mydictionary2 = mylist.ToDictionary(pp => pp.Age, pp => pp); //exact the same sinthax as in case of
			//arrays
			//Using the dictionary
			foreach(var k in mydictionary2.Values)
			{
				Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}", k.Name, k.Age, k.Gender); //same as above.
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class People
	{
		public int Age {get; set;}
		public string Name {get; set;}
		public char Gender{get; set;}
	}
}