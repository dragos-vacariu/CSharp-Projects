/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 12:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; // used for dictionary.
using System.Linq; //used for dictionary count functions.

/*A dictionary is a datatype that is present in System.Collections.Generic and it's very similar to a List. Except that a dictionary
 is a collection of key-value pair, whereas list is just a collection of values.
 The keys within a dictionary must be unique. There cannot be 2 values with the same key (this will result exception thrown)'
 Trying to retrieve the values from a dictionary using a wrong key will result also in exception thrown.*/
namespace project51_dictionary
{
	class Program
	{
		public static void Main(string[] args)
		{
			People p1 = new People {Age=22, Name="Mark", Gender='M'};
			People p2 = new People {Age=43, Name="Darren", Gender='M'};
			People p3 = new People {Age=11, Name="Jasmin", Gender='F'};
			//Creating a dictionary
			Dictionary<int,People> dictionaryPeople = new Dictionary<int,People>(); //The first parameter in our case int is the input parameter
			//the argument that will be passed on when calling the dictionary. The second parameter in our case People is the return type of the
			//dictionary
			dictionaryPeople.Add(p1.Age, p1);
			dictionaryPeople.Add(p2.Age, p2);
			dictionaryPeople.Add(p3.Age, p3);
			//Using the dictionary.
			Console.WriteLine("The human with age=22 from dictionar is named: {0}, and is a: {1}"
			                  , dictionaryPeople[22].Name, dictionaryPeople[22].Gender);
			//Using foreach loop for dictionary.
			Console.WriteLine("Getting the key for each person in the dictionary:");
			//To use foreach loop on a dictionary you need to use KeyValuePair to specify the input type and output type for the parameters:
			//or simply use var keyword
			foreach (KeyValuePair<int, People> k in dictionaryPeople) //Equivalent: foreach(var k in dictionaryPeople)
			{
				//Getting the age of each person in the dictionary:
				Console.WriteLine("Age: {0}", k.Key);
			}
			Console.WriteLine("\nGetting the values for each person in the dictionary:");
			//Using the equivalent method:
			foreach (var k in dictionaryPeople) //Equivalent: foreach (KeyValuePair<int, People> k in dictionaryPeople)
			{
				//Getting the value of each person in dictionary:
				Console.WriteLine("Value: {0}", k.Value); //k.Value returns the path to the object class (namespace.class);
			}
			Console.WriteLine("\nGetting all the details for each person in the dictionary:");
			foreach (var k in dictionaryPeople)
			{
				//Getting all the details for each person in the dictionary:
				Console.WriteLine("Name: {0}	Age: {1}	Gender: {2}", k.Value.Name, k.Value.Age, k.Value.Gender); //k.value.propriety to 
				//get a propriety of the object.
			}
			//Checking if the dictionary contains a certain key:
			if(dictionaryPeople.ContainsKey(22))
			{
				Console.WriteLine("A person with key 22 is already in the dictionary!");
			}
			//Using TryGetValue(), it will check if a certain key exists in the dictionary and if it exists it will provide the value, otherwise
			//you can display an error message instead of an exception message. TryGetValue for dictionary is similar to TryParse for integers.
			People check;
			if(dictionaryPeople.TryGetValue(111, out check))
			{
				Console.WriteLine("The key is valid! Name within the key: {0}", check.Name);
			}
			else
			{
				Console.WriteLine("The key does not exists in the dictionary.");
			}
			//Using Count Property and Count Overloaded functions to count the items within the dictionary:
			Console.WriteLine("Total items in dictionary: {0} (using property)", dictionaryPeople.Count); //using property
			//These functions are present in System.Linq namespace
			Console.WriteLine("Total items in dictionary: {0} (using default function)", dictionaryPeople.Count()); //using default function
			Console.WriteLine("Total items with age greater than 20: {0} (using overloaded function)", 
			   dictionaryPeople.Count(obj=> obj.Value.Age >20)); //using overloaded function (similar to FirstOrDefault function for lists).
			//In function above obj is called predicate.
			
			//Removing an item from the dictionary:
			dictionaryPeople.Remove(22); //22 is the key. In case that the key does not exists in the dictionary nothing happens.
			Console.WriteLine("Total items (after removal): {0}", dictionaryPeople.Count());
			//Clearing the dictionary (erasing everything):
			dictionaryPeople.Clear();
			Console.WriteLine("Total items (after clear): {0}", dictionaryPeople.Count());
			//End of program.
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