/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 12.12.2016
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

/*A queue is a collection type just like a list or dictionary, dispite that once an object is retrieved from Queue (Dequeue), that object gets
 automatically deleted from the beggining of the Queue.*/
 
/*You can thing of a Queue just like an RAR archieve, because to use an object from the Queue, that object needs to be Dequeued into an another
  object, otherwise it will affect the entire content of the Queue, unless an foreach loop it's used.
  To prevent an object be deleted from the Queue, you have to use a foreach loop or the .Peak function, also you can iterate through the Queue using foreach loop, 
  and effect changes without affecting the content of the Queue.
 */

namespace queue_collection_type
{
	class Program
	{
		public static void Main(string[] args)
		{
			people p1 = new people ("Black", 22);
			people p2 = new people ("Mark", 24);
			
			//Creating Queue
			Queue <people> FirstQueue = new Queue <people> ();
			FirstQueue.Enqueue(p1);
			FirstQueue.Enqueue(p2);
			//Printing Information:
			Console.WriteLine("Number of objects in Queue: {0}\n", FirstQueue.Count());
			
			// Console.WriteLine ("Name: {0}, Age: {1}", FirstQueue.Dequeue().name, FirstQueue.Dequeue().Age); //this is wrong, unless it is
			//moved into a foreach loop:
			
			//A Queue is like an archieve, you need to extract the object from it, before using that object.
			Queue<people> SecondQueue = new Queue<people> ();
			SecondQueue.Enqueue(p1);
			SecondQueue.Enqueue(p2);
			people deq1 = FirstQueue.Dequeue();
			people deq2 = FirstQueue.Dequeue();
			
			/*SecondQueue=FirstQueue // these two Queues become highly connected one to another in the way that, SecondQueue take all the objects
			 from the FirstQueue, but if in FirstQueue an object is removed so it is in the SecondQueue.*/
			
			Console.WriteLine("Name: {0}, Age: {1}", deq1.name, deq1.Age);
			Console.WriteLine("Name: {0}, Age: {1}", deq2.name, deq2.Age);
			Console.WriteLine();
			//Auxiliar way -> Iteration:
			foreach (people p in SecondQueue)
			{
				Console.WriteLine("Name: {0}, Age: {1}", p.name, p.Age);
				Console.WriteLine ("Number of objects in Queue: {0}", FirstQueue.Count());
				Console.WriteLine("In the foreach loop the content of the Queue is it not affected, \n(Dequeue is made without removal).\n");
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	class people 
	{
		public int Age {get; set;}
		public string name {get; set;}
		public people (string GivenName, int GivenAge) 
		{
			this.Age = GivenAge; 
			this.name = GivenName;
		}
	}
}