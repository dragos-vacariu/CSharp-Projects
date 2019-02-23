/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 12.12.2016
 * Time: 19:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

/*
 * A stack uses the principle LIFO - Last In First Out, it is just like a list.
 * Once an element gets retrieved from the Stack that object will be removed, unless a foreach loop, or the Peek function it's used.
 */
namespace project61_stack_collection_type
{
	class Program
	{
		public static void Main(string[] args)
		{
			people p1 = new people ("Dragos", 22);
			people p2 = new people ("Adrian", 21);
			Stack<people> FirstStack = new Stack<people>();
			FirstStack.Push(p1);
			FirstStack.Push(p2);
			//The first will be the last:
			foreach (people p in FirstStack)
			{
				Console.WriteLine("Name: {0}	Age: {1}", p.Name, p.Age);
				Console.WriteLine("Number of elements on Stack: {0}", FirstStack.Count);
			}
			Console.WriteLine();
			Console.WriteLine("Outside the forech loop:");
			Console.WriteLine("Name: {0}", FirstStack.Pop().Name);
			Console.WriteLine("Number of elements on Stack: {0}", FirstStack.Count);
			Console.WriteLine("Name: {0}", FirstStack.Pop().Name);
			Console.WriteLine("Number of elements on Stack: {0}", FirstStack.Count);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class people
	{
		public string Name {get; set;}
		public int Age {get; set;}
		public people (string NewName, int NewAge) {Name=NewName; Age=NewAge;}
	}
}