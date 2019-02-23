using System;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Software
{
	class Software{
		/*
		 NOTE: Enums cannot be declared inside a function, or method. NOT EVEN the Main function.
		 */
		enum Gamestate {Playing, Menu, Pause=6}; //from now on, Gamestate is like a datatype.
		/*From the moment of declaration the enum is initializing to true the first state. In this case
		 * Playing = true, until the programmer sets it otherwise.
		 * The elements of the enum can also hold values, as it sets above, Pause = 6, Playing = 0, Menu = 1 
			(by default the	value set for each element is its index).
		 */
		public static int Main()
		{
			//Creating an object/instance for the enum;
			Gamestate gamestate;
			Console.WriteLine("Gamestate: " + Convert.ToInt32(Gamestate.Pause));
			Console.WriteLine("Gamestate: " + Convert.ToInt32(Gamestate.Playing));
			//Changing the state of the Gamestate enum;
			gamestate=Gamestate.Menu;
			/*Equivalence for this case:
			 * bool Playing = false;
			 * bool Menu = true;
			 * bool Pause = false;
			 * 
			 * As denoted, the enum is like an array of boolean values, in which only one can be true at a time.
			 * This is useful while creating game engines, or software engines, to know when a certain option is
			 * available. Also this is used to control and interract the states in a certain application.
			 */
			Console.WriteLine("Gamestate: " + gamestate);		
			gamestate=Gamestate.Playing;
			/*Equivalence:
			 * bool Playing = true;
			 * bool Menu = false;
			 * bool Pause = false;
			 */
			Console.WriteLine("Gamestate: " + gamestate);
			
			//Interraction of the user:
			int input=9;
			while(input>0&&input<10)
			{
				Console.WriteLine("Enter the option: ");
				input = Convert.ToInt16 (Console.ReadLine());
				switch(input)
				{
						case 1:
						{
							gamestate = Gamestate.Menu;
							Console.WriteLine("The active state: " + gamestate);
							break;
						}
						case 2:
						{
							gamestate = Gamestate.Pause;
							Console.WriteLine("The active state: " + gamestate);
							break;
						}
						case 3:
						{
							gamestate = Gamestate.Playing;
							Console.WriteLine("The active state: " + gamestate);
							break;
						}
						default:
						{
							Console.WriteLine("This is not a gamestate");
							break;
						}
				}
			}
			Console.WriteLine("Out of the loop!");
			Console.ReadLine();
			return 0;
		}
	}
}