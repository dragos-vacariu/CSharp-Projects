/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 23.07.2016
 * Time: 20:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project59_artifficial_intelligence
{
	class Program
	{
		public static void Main(string[] args)
		{
			Game newgame = new Game();
			Player HumanPlayer = new Player();
			CPU CpuPlayer = new CPU();
			string answear = "Y";
			while(answear == "Y")
			{
				Console.Clear();
				if(answear=="Y")
				{
					newgame.initializeTable(newgame);
					newgame.printTable();
					int round=0;
					while(!newgame.gameOver)
					{
						round++;
						HumanPlayer.PlayerTurn(newgame);
						if(!newgame.CheckWinner(round))
						{
							round++;
							CpuPlayer.OpponentTurn2(newgame,round);
							newgame.CheckWinner(round);
						}
						else
						{
							Console.Clear();
							newgame.CheckWinner(round);
							newgame.printTable();
						}
					}
					answear="P";
				}
				Console.WriteLine("Game over!\nDo you want to play again? Y\\N");
				while(answear!="Y" && answear!="N")
				{
					if(answear!="Y" && answear!="N")
					{
						Console.WriteLine("Answear only with Y or N!");
					}
					answear = Convert.ToString(Console.ReadLine());
					answear = answear.ToUpper();
				}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	public class Game
	{
		protected char Player_Symbol = 'X';
		protected char CPU_Symbol = 'O';
		public bool gameOver=false;
		public char [,] table = new char[3,3];
		protected int choiceX,choiceY;
		public void initializeTable(Game obj)
		{
			for(int i=0; i<3;i++)
			{
				for(int j=0;j<3;j++)
				{
					table[i,j]='.';
				}
			}
			obj.gameOver=false;
		}
		public void printTable()
		{
			for(int i=0; i<3;i++)
			{
				for(int j=0;j<3;j++)
				{
					Console.Write("{0}", table[i,j]);
				}
				Console.WriteLine();
			}
		}
		public bool CheckWinner(int round)
		{
			if(table[0,0]==table[0,1]&&table[0,1]==table[0,2])
			{
				if(table[0,0]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,0]);
					gameOver=true;
					return true;
				}
			}
			else if(table[1,0]==table[1,1]&&table[1,1]==table[1,2])
			{
				if(table[1,0]!='.')
				{
					Console.WriteLine("{0} is winner!", table[1,0]);
					gameOver=true;
					return true;
				}
			}
			else if(table[2,0]==table[2,1]&&table[2,1]==table[2,2])
			{
				if(table[2,0]!='.')
				{
					Console.WriteLine("{0} is winner!", table[2,0]);
					gameOver=true;
					return true;
				}
			}
			else if(table[0,0]==table[1,0]&&table[1,0]==table[2,0])
			{
				if(table[0,0]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,0]);
					gameOver=true;
					return true;
				}
			}
			else if(table[0,1]==table[1,1]&&table[1,1]==table[2,1])
			{
				if(table[0,1]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,1]);
					gameOver=true;
					return true;
				}
			}
			else if(table[0,2]==table[1,2]&&table[1,2]==table[2,2])
			{
				if(table[0,2]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,2]);
					gameOver=true;
					return true;
				}
			}
			else if(table[0,0]==table[1,1]&&table[1,1]==table[2,2])
			{
				if(table[0,0]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,0]);
					gameOver=true;
					return true;
				}
			}
			else if(table[0,2]==table[1,1]&&table[1,1]==table[2,0])
			{
				if(table[0,2]!='.')
				{
					Console.WriteLine("{0} is winner!", table[0,2]);
					gameOver=true;
					return true;
				}
			}
			else if(round>=9)
			{
				Console.WriteLine("Game has ended as a draw!");
				gameOver=true;
				return true;
			}
			gameOver=false;
			return false;
		}
	}
	class Player:Game
	{
		public void PlayerTurn(Game obj)
		{
			bool NotReady=true;
			while(NotReady)
			{
				this.GetCoordinates();
				if(obj.table [base.choiceX, base.choiceY]!='.')
				{
					Console.WriteLine("That position is occupied!");
				}
				else
				{
					NotReady=false;
					obj.table[base.choiceX, base.choiceY]='X';
				}
			}
		}
		private void GetCoordinates()
		{
			base.choiceX=-1;
			base.choiceY=-1;
			while(base.choiceX<0||base.choiceX>2)
			{
				Console.WriteLine("Enter the line for your move: (between 0 - 2)");
				base.choiceX = Convert.ToInt32(Console.ReadLine());
			}
			while(base.choiceY<0||base.choiceY>2)
			{
				Console.WriteLine("Enter the column for your move: (between 0 - 2)");
				base.choiceY = Convert.ToInt32(Console.ReadLine());
			}
		}
	}
	class CPU: Game
	{
		private int CPUx, CPUy;
		public void OpponentTurn2(Game obj, int round) //the second intelligent function
		{
			int posx,posy;
			if(AImove(obj, round, base.CPU_Symbol, out posx, out posy))
			{
				obj.table[posx,posy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AImove(obj, round, base.Player_Symbol, out posx, out posy))
			{
				obj.table[posx,posy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			AImove(obj, round, base.Player_Symbol, out posx, out posy);
			obj.table[posx,posy]='O';
			Console.Clear();
			obj.printTable();
			return;
		}
		private bool AImove(Game obj, int round, char Symbol, out int posx, out int posy)
		{
			posx=0;
			posy=0;
			for(int i=0;i<3;i++)
			{
				for (int j=0;j<3;j++)
				{
					if(obj.table[i,j]=='.')
					{
						obj.table[i,j]=Symbol;
						if(!obj.CheckWinner(round))
						{
							obj.table[i,j]='.';
							posx=i;
							posy=j;
							continue;
						}
						else if(obj.CheckWinner(round))
						{
							obj.table[i,j]='.';
							posx=i;
							posy=j;
							return true;
						}
					}
				}
			}
			return false;
		}
		public void OpponentTurn(Game obj) //the first intelligent function.
		{
			if(AreThereTwoInDiagPrin(obj, base.Player_Symbol, out CPUy, out CPUx) || 
			   AreThereTwoInDiagPrin(obj, base.CPU_Symbol, out CPUy, out CPUx))
			{
				obj.table[CPUx,CPUy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInDiagSec(obj, base.Player_Symbol, out CPUy, out CPUx) ||
			       AreThereTwoInDiagSec(obj, base.CPU_Symbol, out CPUy, out CPUx))
			{
				obj.table[CPUx,CPUy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInRow(obj, base.Player_Symbol, 0, out CPUy) ||
			       AreThereTwoInRow(obj, base.CPU_Symbol, 0, out CPUy))
			{
				obj.table[0,CPUy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInRow(obj, base.Player_Symbol, 1, out CPUy) ||
			       AreThereTwoInRow(obj, base.CPU_Symbol, 1, out CPUy))
			{
				obj.table[1,CPUy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInRow(obj, base.Player_Symbol, 2, out CPUy) ||
			       AreThereTwoInRow(obj, base.CPU_Symbol, 2, out CPUy))
			{
				obj.table[2,CPUy]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInColumn(obj, base.Player_Symbol, 0, out CPUx) ||
			       AreThereTwoInColumn(obj, base.CPU_Symbol, 0, out CPUx))
			{
				obj.table[CPUx,0]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInColumn(obj, base.Player_Symbol, 1, out CPUx) ||
			       AreThereTwoInColumn(obj, base.CPU_Symbol, 1, out CPUx))
			{
				obj.table[CPUx,1]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else if(AreThereTwoInColumn(obj, base.Player_Symbol, 2, out CPUx) ||
			       AreThereTwoInColumn(obj, base.CPU_Symbol, 2, out CPUx))
			{
				obj.table[CPUx,2]='O';
				Console.Clear();
				obj.printTable();
				return;
			}
			else
			{
				GetClosePosition(obj, out CPUx, out CPUy);
				if(CPUx!=-1&&CPUy!=-1)
				{
					obj.table[CPUx,CPUy]='O';
					Console.Clear();
					obj.printTable();
					return;
				}
			}
		}
		private bool AreThereTwoInRow(Game obj, char Symbol, int line, out int colomn)// used for OpponentTurn;
		{
			colomn=-1;
			int counter=0;
			for(int j=0;j<3;j++)
			{
				if(obj.table[line,j]==Symbol)
				{
					counter++;
				}
				else if(obj.table[line,j]=='.')
				{
					colomn=j;
				}
			}
			if(counter==2&&colomn!=-1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool AreThereTwoInColumn(Game obj, char Symbol, int column, out int line)//used for OpponentTurn
		{
			line=-1;
			int counter=0;
			for(int j=0;j<3;j++)
			{
				if(obj.table[j, column]==Symbol)
				{
					counter++;
				}
				else if(obj.table[j, column]=='.')
				{
					line=j;
				}
			}
			if(counter==2&&line!=-1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool AreThereTwoInDiagPrin(Game obj, char Symbol,  out int column, out int line) //used for OpponentTurn
		{
			line=-1;
			column=-1;
			int counter=0;
			for(int i=0;i<3;i++)
			{
				for(int j=0;j<3;j++)
				{
					if(i==j)
					{
						if(obj.table[i,j]==Symbol)
						{
							counter++;
						}
						else if(obj.table[i,j]=='.')
						{
							column=j;
							line=i;
						}
					}
				}
			}
			if(counter==2 && line!=-1 && column!=-1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool AreThereTwoInDiagSec(Game obj, char Symbol,  out int column, out int line) //used for OpponentTurn
		{
			line=-1;
			column=-1;
			int counter=0;
			for(int i=0;i<3;i++)
			{
				for(int j=0;j<3;j++)
				{
					if(i+j==2)
					{
						if(obj.table[i,j]==Symbol)
						{
							counter++;
						}
						else if(obj.table[i,j]=='.')
						{
							column=j;
							line=i;
						}
					}
				}
			}
			if(counter==2 && line!=-1 && column!=-1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void GetClosePosition(Game obj, out int line, out int column) //used for OpponentTurn
		{
			line=-1;
			column=-1;
			if(base.choiceX==base.choiceY)
			{
				for(int i=0;i<3;i++)
				{
					for(int j=0;j<3;j++)
					{
						if(i==j)
						{
							if (obj.table[i,j]=='.')
							{
								line=i;
								column=j;
								return;
							}
						}
					}
				}
			}
			if(base.choiceX+base.choiceY==2)
			{
				for(int i=0;i<3;i++)
				{
					for(int j=0;j<3;j++)
					{
						if(i+j==2)
						{
							if (obj.table[i,j]=='.')
							{
								line=i;
								column=j;
								return;
							}
						}
					}
				}
			}
			for(int j=0;j<3;j++)
				{
					if (obj.table[base.choiceX,j]=='.')
					{
						line=base.choiceX;
						column=j;
						return;
					}
				}
			for (int j=0;j<3;j++)
			{
				if (obj.table[j,base.choiceY]=='.')
				{
					line=j;
					column=base.choiceY;
					return;
				}
			}
		}
	}
}