/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.12.2016
 * Time: 20:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace project66_word_game
{
	class Program
	{
		public static void Main(string[] args)
		{
			bool gameover = false;
			uint level = 1;
			string answear="garbage";
			List <WordGame> Game = new List<WordGame>{};
			Game.Add(new WordGame("SRKENADS","DARKNESS", "It comes once with the night!",(uint) Game.Count+1));
			Game.Add(new WordGame("WMTORORO", "TOMORROW", "It comes in future!", (uint) Game.Count+1));
			Game.Add(new WordGame("DNGRUNDOUER", "UNDERGROUND", "Its placed below the surface!", (uint) Game.Count+1));
			Game.Add(new WordGame("MNETRTPAA", "APARTMENT", "A place to stay!", (uint) Game.Count+1));
			Game.Add(new WordGame("TNOCELRACAEI", "ACCELERATION", "Force of a car!", (uint) Game.Count+1));
			Game.Add(new WordGame("SERPEDISNO", "DEPRESSION", "Excessive sadness!", (uint) Game.Count+1));
			Game.Add(new WordGame("NTLGENCEINIEL", "INTELLIGENCE", "Power of the brain!", (uint) Game.Count+1));
			Game.Add(new WordGame("DTONRAYCII", "DICTIONARY", "A book full of words!", (uint) Game.Count+1));
			Game.Add(new WordGame("WUNDTREAER", "UNDERWATER", "A place where fish can live!", (uint) Game.Count+1));
			Game.Add(new WordGame("RANORMSTBI", "BRAINSTORM", "An idea that comes suddenly!", (uint) Game.Count+1));
			Game.Add(new WordGame("MTHACITAEMS", "MATHEMATICS", "Difficult field of study!", (uint) Game.Count+1));
			Game.Add(new WordGame("NLOGTYCHEO", "TECHNOLOGY", "Something that is related to engineering!", (uint) Game.Count+1));
			Game.Add(new WordGame("SUTAHLOCO", "HOLOCAUST", "A mass of destruction!", (uint) Game.Count+1));
			Game.Add(new WordGame("PRGRMIGNOMA", "PROGRAMMING", "Language used by computers!", (uint) Game.Count+1));
			Game.Add(new WordGame("RCSADORSO", "CROSSROAD", "Ways meeting up together!", (uint) Game.Count+1));
			Game.Add(new WordGame("LMOGRABHIIN", "LAMBORGHINI", "Fast and expensive car!", (uint) Game.Count+1));
			Game.Add(new WordGame("WPOHRSEROE", "HORSEPOWER", "Force that makes a car able to fly!", (uint) Game.Count+1));
			Game.Add(new WordGame("PREGOEKAEL", "GOALKEEPER", "Possition on a footbal team!", (uint) Game.Count+1));
			Game.Add(new WordGame("LNDSAPCAE", "LANDSCAPE", "Something that's seen in a picture!", (uint) Game.Count+1));
			Game.Add(new WordGame("AMIONHCIPSPI", "CHAMPIONSHIP", "A big competition!", (uint) Game.Count+1));
			while(!gameover)
			{
				foreach(WordGame k in Game)
				{
					if(k.GetLevel()==level)
					{
						do
						{
							Console.Clear();
							DisplayTop();
							k.Display_DisplayedWord();
							k.DisplayLevel();
							k.DisplayChances();
							k.DisplayClue();
							Console.WriteLine("Enter your answear: ");
							answear = Convert.ToString(Console.ReadLine());
							answear = answear.ToUpper();
						}
						while(!k.CheckAnswear(answear, ref level) && !k.CheckGameOver(ref gameover));
					}
					if(level==21)
					{
						Console.WriteLine("Congratulations! You found and completed all the words in this game.");
						gameover=true;
						break;
					}
				}
				
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void DisplayTop()
		{
			Console.WriteLine("W E L C O M E___T O___M Y___A N A G R A M___G A M E");
			Console.WriteLine("##########################################################\n");
		}
	}
	class WordGame
	{
		string DisplayedWord;
		string AnswearWord;
		string Clue;
		uint index_level;
		uint chances;
		public WordGame(string newDisplayedWord, string newAnswearWord, string Clue_Message ,uint new_index_level)
		{
			DisplayedWord = newDisplayedWord;
			AnswearWord = newAnswearWord;
			index_level = new_index_level;
			Clue = Clue_Message;
			chances=10;
		}
		public void DisplayChances()
		{
			Console.WriteLine("You have {0} chances left for this word.", this.chances);
		}
		public void DisplayLevel ()
		{
			Console.WriteLine("Level: {0}", this.index_level);
		}
		public void DisplayClue()
		{
			Console.WriteLine("Clue: {0}", this.Clue);
		}
		public bool CheckAnswear(string UserAnswear, ref uint level)
		{
			if(UserAnswear==this.AnswearWord)
			{
				Console.WriteLine("Congratulations. You answered perfectly!");
				level++;
				return true;
			}
			else
			{
				this.chances--;
				return false;
			}
		}
		public bool CheckGameOver(ref bool gameover)
		{
			if(chances<=0)
			{
				Console.WriteLine("Game Over! Your chances reached 0.");
				gameover = true;
				return true;
			}
			return false;
		}
		public void Display_DisplayedWord()
		{
			Console.WriteLine("Anagram: {0}", this.DisplayedWord);
		}
		//Getters
		public uint GetLevel()
		{
			return this.index_level;
		}
	}
}