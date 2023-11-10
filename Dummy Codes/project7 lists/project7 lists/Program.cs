using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project7_lists
{
	class Program
	{
		public static void Main(string[] args)
		{
			List <int> MyList = new List<int> ();
			
			for(int i=1;i<=10;i++)
			{
				MyList.Add(i*6);
			}
			int counter=0;
			foreach(int iter in MyList)
			{
				Console.WriteLine("Element[" + counter+"]" + " is " + iter);
				counter++;
			}
			//Removing elements from the list.
			MyList.RemoveAt(5); // remove the element at index 5.
			counter=0;
			Console.WriteLine("\nAfter removal.");
			foreach(int iter in MyList)
			{
				Console.WriteLine("Element[" + counter+"]" + " is " + iter);
				counter++;
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}