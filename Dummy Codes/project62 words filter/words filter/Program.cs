/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 12.12.2016
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace words_filter
{
	class Program
	{
		public static void Main()
		{
			string message;
			Console.WriteLine("Write a message. Do not type \"fuck\" in there! ");
			message = Console.ReadLine();
			char [] cstring = message.ToCharArray();
			for(int i =0; i < cstring.Length; i++)
			{
				if(i+2 <= cstring.Length)
				{
					if(cstring[i] == 'F' || cstring [i]  == 'f')
					{
						if(cstring[i+1] == 'U' || cstring [i+1] == 'u')
						{
							if (cstring [i+2] == 'C' || cstring [i+2] == 'c')
							{
								cstring [i] = cstring[i+1] = cstring [i+2] = '*';
							}
						}
					}
				}
			}
			Console.WriteLine(cstring);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
	}
}