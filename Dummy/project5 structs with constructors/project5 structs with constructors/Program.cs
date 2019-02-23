using System;

/*A struct is a similar data type with a class, but structs works with values, while classes works as reference
 	FOR A STRUCT:
 	if we create 2 objects:
 	object1 = object2, in this case object1 will have all the values that object2 has.
 	
 	FOR A CLASS:
 	if we create 2 objects:
 	object1 = object2, in this case object1, will be poiting to the object2's values which are stored on the heap.
 */

namespace project5_structs_with_constructors
{
	class Program
	{
		struct MyStr
			{
				//Variables of the struct:
				public int posx, posy;
				//Constructor of the struct:
				public MyStr (int newposx, int newposy)
				{
					posx = newposx;
					posy = newposy;
				}
			}
		public static void Main(string[] args)
		{
			//Creating the instances/objects of the struct
			MyStr structure1 = new MyStr (4, 5);
			MyStr structure2 = new MyStr (10, 12);
			//Printing the values:
			Console.WriteLine("The first structure has: X=" +structure1.posx +" and Y=" +structure1.posy);
			Console.WriteLine("The second structure has: X=" +structure2.posx +" and Y=" +structure2.posy);
			structure1 = structure2;
			//Printing the values:
			Console.WriteLine("\nAfter setting structure1 = structure2.\n");
			Console.WriteLine("The first structure has: X=" +structure1.posx +" and Y=" +structure1.posy);
			Console.WriteLine("The second structure has: X=" +structure2.posx +" and Y=" +structure2.posy);
			//End of program:
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}