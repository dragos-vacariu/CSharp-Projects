/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic; //using this for lists and collections;

namespace project56_sorting_a_list
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<int>mylist = new List<int>(1);
			mylist.Add(23);
			mylist.Add(3);
			mylist.Add(2);
			mylist.Add(24);
			mylist.Add(233);
			mylist.Add(213);
			mylist.Add(31);
			Program.SortingListIncreasingOrder(mylist);
			Console.WriteLine("Sorting with Sort() Function:\n");
			mylist.Sort();
			Program.SortingListDecreasingOrder(mylist);
			Console.WriteLine("Sorting with Reverse() Function:\n");
			mylist.Reverse();
			//Sorting string list:
			List<string>mystringList = new List<string>(1);
			mystringList.Add("N");
			mystringList.Add("E");
			mystringList.Add("G");
			mystringList.Add("L");
			mystringList.Add("I");
			mystringList.Add("P");
			Console.WriteLine("Sorting strings with Sort() Function:\n");
			mystringList.Sort();
			DisplayList(mystringList);
			Console.WriteLine("Sorting strings with Reverse() Function:\n");
			mystringList.Reverse();
			DisplayList(mystringList);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//Creating a sorter function:
		public static void SortingListIncreasingOrder(List<int> mylist)
		{
			Console.WriteLine("Sorting in increasing order\n");
			int aux=0;
			for(int i=0;i<mylist.Count;i++)
			{
				for(int j=0;j<mylist.Count;j++)
				{
					if(mylist[i]<mylist[j])
					{
						aux=mylist[j];
						mylist[j]=mylist[i];
						mylist[i]=aux;
					}
				}
			}
			DisplayList(mylist);
		}
		public static void SortingListDecreasingOrder(List<int> mylist)
		{
			Console.WriteLine("Sorting in decreasing order\n");
			int aux=0;
			for(int i=0;i<mylist.Count;i++)
			{
				for(int j=0;j<mylist.Count;j++)
				{
					if(mylist[i]>mylist[j])
					{
						aux=mylist[j];
						mylist[j]=mylist[i];
						mylist[i]=aux;
					}
				}
			}
			DisplayList(mylist);
		}
		public static void DisplayList<T>(List<T> mylist)
		{
			foreach (T k in mylist)
			{
				Console.WriteLine("{0} ", k);
			}
		}
	}
}