/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 16.07.2016
 * Time: 14:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project12_new_types_null_coalescing_operator
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*Non-Nullable type: Are Value TYPES: integers, boolean, double, float, long, long long, char...etc
			 * Nullable type: Are Reference TYPES: classes, interface, delegates, arrays... etc
			 * 
			 * A Non-Nullable type can become Nullable type by using ? in their declaration.
			 * Examples:
			 */
			bool major = false; //non-nullable value type.
			bool ?minor = null; //nullable value type. 
			/*A nullable boolean type can hold on to 3 values: true, false or null.
			 */
			Console.WriteLine("Are you a minor? Press Y/N to answear or anything else to skip.");
			char answear=Convert.ToChar(Console.ReadLine());
			switch(answear)
			{
				case 'y':  minor = true; break;
				case 'Y': minor = true; break;
				case 'n':  minor = false; break;
				case 'N': minor = false; break;
				default: minor = null; break;
			}
			if(minor==true)
			{
				Console.WriteLine("You are minor!");
			}
			else if(minor==false)
			{
				Console.WriteLine("You are not minor!");
			}
			else
			{	
				Console.WriteLine("You did not answear the question!");
			}
			//NULL COALESCING OPERATOR:
			int? TicketsOnSale = 100;
			int availableTickets=TicketsOnSale??0; //if TicketsOnSale is null, availableTickets will be 0, otherwise
			//availableTickets = (int)TicketsOnSale.
			/*Equivalent method:
			 * if(TicketsOnSale==null)
			 * {
			 * 		availableTickets=0;
			 * }
			 * else
			 * {
			 * 		availableTickets=(int)TicketsOnSale; //TicketsOnSale is a nullable int, so it must be
			 * 		//casted to normal int.
			 * 		
			 * 		//Other method of casting:
			 * 		//available Tickets=TicketsOnSale.value;
			 * }
			 */
			Console.WriteLine("Available Tickets: {0}", availableTickets);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}