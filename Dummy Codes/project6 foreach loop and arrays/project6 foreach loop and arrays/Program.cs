using System;

namespace project6_foreach_loop
{
	class Program
	{
		public static void Main(string[] args)
		{
			int [] myarray = new int[10];
			for (int i=0;i<10;i++)
			{
				myarray[i]=3*i;
			}
			Console.WriteLine("\nDisplaying elements using FOR LOOP: ");
			for (int i=0;i<10;i++)
			{
				Console.WriteLine("myarray[" + i + "]=" +myarray[i]);
			}
			Console.WriteLine("\nDisplaying elements using FOREACH LOOP: ");
			/*FOREACH LOOP is used especially when trying to iterrate into a list which has dinamic size, or 
			 * an array with unknown size.
			 * FOREACH is very similar to a FOR loop. FOREACH is used only for Collection of data.
			 * The difference between FOR LOOP and FOREACH LOOP is that in FOREACH LOOP there is no access to
			 * the index.
			 */
			foreach(int iter in myarray) // synthax forech (datatype iterator_name in data_collection)
			{
					Console.WriteLine("myarray[" + iter/3 + "]=" +iter);
			}
			Console.WriteLine("\nSimple task for FOREACH LOOP");
			foreach(int iter in myarray) // synthax forech (datatype iterator_name in data_collection)
			{
				if(iter%5==0&&iter>0)
				{
					Console.WriteLine (iter + " is divisible with five.");
				}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}