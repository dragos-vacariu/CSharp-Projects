/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 19.12.2016
 * Time: 19:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace project69_who_wants_to_be_a_millionaire
{
	class Program
	{
		static string path = "highscore.txt";
		public static void Main(string[] args)
		{
			string answearFinal = "Y";
			while(answearFinal=="Y" || answearFinal == "y")
			{
				Console.Clear();
				bool IsGameOver=false;
				Question_Object randomObjectGetter;
				string GivenAnswear;
				string BadAnswearOutput_1 = "Garbage"; //needed to initialize this with some garbage;
				string BadAnswearOutput_2 = "Garbage";
				uint level=1;
				uint difficulty=1;
				uint money=0;
				uint multiplier=1;
				uint chances=0;
				uint NrOfAnswears = 4;
				bool EnterItemShop=false; //just a flag
				string highscore = "Uninitialized"; //garbage intialization
				string newHighScore;
				GetHighestScore(ref highscore);
				List<Question_Object> Difficulty_One = new List<Question_Object>{};
				GettingTheQuestions(Difficulty_One, level);
				while(!IsGameOver && GetRandomQuestion(Difficulty_One, out randomObjectGetter) && level<=80)
				{
					if(EnterItemShop)
					{
						ItemShop(ref money, ref multiplier, ref chances, ref NrOfAnswears);
						EnterItemShop=false;
					}
					DisplayTop();
					SetANewHighScore(highscore, money, out newHighScore);
					Console.WriteLine("Money: {0}$\nLevel: {1}\nDifficulty: {2}\nMultiplier: {3}\nChances left: {4}\nHighest Score: {5}", 
					                  money, level, difficulty, multiplier, chances, newHighScore);
					randomObjectGetter.PrintQuestion();
					if(NrOfAnswears==4)
					{
						randomObjectGetter.PrintAnswears();
					}
					else if(NrOfAnswears==3)
					{
						randomObjectGetter.PrintSpecialAnswears3(ref BadAnswearOutput_1, ref BadAnswearOutput_2);
					}
					else //enter here if NrOfAnswears == 2;
					{
						randomObjectGetter.PrintSpecialAnswears2(ref BadAnswearOutput_1);
					}
					Console.WriteLine("\nType in your final answear:");
					GivenAnswear=Convert.ToString(Console.ReadLine());
					while(!CheckGivenAnswear(GivenAnswear,randomObjectGetter, NrOfAnswears, BadAnswearOutput_1, BadAnswearOutput_2))
					{
						Console.WriteLine("\nThis answear doesn't exist!\nType a valid answear!");
						GivenAnswear=Convert.ToString(Console.ReadLine());
					}
					if(!randomObjectGetter.CheckCorrectAnswear(GivenAnswear, level, money, multiplier, ref EnterItemShop, out money))
					{
						if(chances==0)
						{
							IsGameOver=true;
						}
						else
						{
							chances--;
							Console.WriteLine("Your answear was wrong. \nYou have: {0} chances left", chances);
							Console.WriteLine("Press any key to resume the game!");
							Console.ReadKey(true);
							Console.Clear();
						}
					}
					//Changing the difficulty
					else if(level%10==0&&level<=30)
					{
						difficulty++;
						Difficulty_One.Clear();
						GettingTheQuestions(Difficulty_One, level);
						//LEVEL needs to be increased now
						level++;
						
					}
					//Answear was correct;
					else
					{
						level++;
					}
				}
				
				if(level==81 || IsGameOver==true)
				{
					if(level==81)
					{
						Console.WriteLine("Congratulations. You ended up the game!");
					}
					else
					{
						Console.WriteLine("Game Over! You answear was wrong. \nYou have wasted all your chances!");
					}
					SaveScore(money, highscore);
					Console.WriteLine("Do you wish to play again? Y/N");
					answearFinal=Convert.ToString(Console.ReadLine());
					while(answearFinal!="Y" && answearFinal!="y" && answearFinal != "n" && answearFinal != "N")
					{
						Console.WriteLine("Please answear only with Y/N!");
						answearFinal=Convert.ToString(Console.ReadLine());
					}
				}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static bool CheckGivenAnswear(string answear, Question_Object question_obj, uint NumberOfAnswears, string BadAnswear,
		                                    string BadAnswear2)
		{
			if(NumberOfAnswears==4)
			{
				if(answear.ToUpper()==question_obj.GetCorrectAnswear().ToUpper() || answear.ToUpper()==question_obj.GetAnswear1().ToUpper() 
				   || answear.ToUpper()==question_obj.GetAnswear2().ToUpper() || answear.ToUpper()==question_obj.GetAnswear3().ToUpper())
				{
					return true;
				}
				else if(answear.ToUpper()=="A" || answear.ToUpper()=="B" || answear.ToUpper()=="C" || answear.ToUpper()=="D")
				{
					return true;
				}
				return false;
			}
			else if(NumberOfAnswears==3)
			{
				if(answear.ToUpper()==question_obj.GetCorrectAnswear().ToUpper() || answear.ToUpper()==BadAnswear.ToUpper() ||
				   answear.ToUpper()==BadAnswear2.ToUpper())
				{
					return true;
				}
				else if(answear.ToUpper()=="A" || answear.ToUpper()=="B" || answear.ToUpper()=="C")
				{
					return true;
				}
				return false;
			}
			else if(NumberOfAnswears==2)
			{
				if(answear.ToUpper()==question_obj.GetCorrectAnswear().ToUpper()|| answear.ToUpper()==BadAnswear.ToUpper())
				{
					return true;
				}
				else if(answear.ToUpper()=="A" || answear.ToUpper()=="B")
				{
					return true;
				}
				return false;
			}
			return false;
		}
		public static bool GetRandomQuestion(List <Question_Object> questionList, out Question_Object output_object)
		{
			if(questionList.Count>0)
			{
				if(questionList.Count>1)
				{
					Random i = new Random();
					int random_choice = i.Next(0, questionList.Count); //questionlist.Count is never an index, but it can be used
					//as the maxValue argument for random generator, because the maxValue is exclused from range.
					for(int c=0; c<questionList.Count; c++)
					{
						if(c==random_choice)
						{
							output_object = questionList[c];
							questionList.Remove(questionList[c]);
							return true;
						}
					}
				}
				else
				{
					output_object=questionList[0];
					return true;
				}
			}
			output_object=null;
			return false;
		}
		public static void DisplayTop()
		{
			Console.WriteLine("#############################################\nWHO WANTS TO BE A MILLIONAIRE CONSOLE GAME!" +
			                  "\n#############################################\n");
		}
		public static void GettingTheQuestions(List <Question_Object> GameQuestionsList, uint level)
		{
			if(level<10)
			{
				GameQuestionsList.Add(new Question_Object("What football team won the Uefa Champions League Final in 2006?", "Real Madrid", 
				                                          "Arsenal", "AC Milan", "Barcelona"));
				GameQuestionsList.Add(new Question_Object("What is the capital of United Kingdom?", "New Mexico", "Athens", 
			                                       "Bucharest", "London"));
				GameQuestionsList.Add(new Question_Object("How many seasons are in Romania?", "Two", "Three", 
			                                     "Five", "Four"));
				GameQuestionsList.Add(new Question_Object("What is the name of the thunder god in norse mythology?", "Hercules", "Hathor", 
			                                     "Jupiter", "Thor"));
				GameQuestionsList.Add(new Question_Object("Who was John Lenon?", "Movie Actor", "Theatre Actor", 
			                                     "Football Player", "Singer"));
				GameQuestionsList.Add(new Question_Object("Who launched the Facebook web application?", "Bill Gates", "Alexander Duma", 
			                                     "Bjarne Stroustroup", "Mark Zuckerberg"));
				GameQuestionsList.Add(new Question_Object("What is the acranym UFO coming from?", "Unreached Forced Oscillation", "Unhandled Flying Offensive", 
			                                     "Unhandled Frightening Object", "Unidentified Flying Object"));
				GameQuestionsList.Add(new Question_Object("Who is Harry Potter?", "A Vampire", "A Thief", 
			                                     "A Demon", "A Sorcerer"));
				GameQuestionsList.Add(new Question_Object("Which is a faster being?", "Cat", "Lion", 
			                                     "Horse", "Cheetah"));
				GameQuestionsList.Add(new Question_Object("When has the movie Titanic been released?", "1998", "1999", 
			                                     "2001", "1997"));
				GameQuestionsList.Add(new Question_Object("Which of the following is not a computer software?", "AVG", "MPLabX", 
			                                     "FL Studio", "Ethernet"));
				GameQuestionsList.Add(new Question_Object("Where would you take a sick friend?", "Police Department", "Bughouse", 
			                                     "Cemetery", "Hospital"));
				GameQuestionsList.Add(new Question_Object("When did Albert Einstein died?", "1948", "1962", 
			                                     "1952", "1955"));
				GameQuestionsList.Add(new Question_Object("Which country was called USSR?", "China", "Ukraine", 
			                                     "Poland", "Russia"));
				GameQuestionsList.Add(new Question_Object("Which of the following writters has won the nobel prize?", "Deryck Whibley", "Mihai Eminescu", 
			                                     "William Shakespeare", "Gabriel Garcia Marquez"));
				GameQuestionsList.Add(new Question_Object("Which is the hottest place?", "Vanda Station", "Rivadavia", 
			                                     "Athens", "Sahara"));
				GameQuestionsList.Add(new Question_Object("Which of the following movies does not belong to 21st century?", "Lord of the rings", "Avatar", 
			                                     "Hurt Locker", "Taxi Driver"));
				GameQuestionsList.Add(new Question_Object("What is the most popular language in the world?", "French", "Spanish", 
			                                     "English", "Chinesse"));
				GameQuestionsList.Add(new Question_Object("What RAM coming from, when you talk about virtual memory?", "Read Access Memory", "Read Advanced Memory", 
			                                     "Random Advanced Memory", "Random Access Memory"));
				GameQuestionsList.Add(new Question_Object("What was Einstein's favorite field of study?", "Math", "Astronomy", 
			                                     "Informatics", "Physics"));
				GameQuestionsList.Add(new Question_Object("Freddy Mercury was a singer, what kind of music did he singed?", "Dubstep", "Post-Hardcore", 
			                                     "Synth-Pop", "Rock 'n roll"));
				GameQuestionsList.Add(new Question_Object("What colors will you find on the Italian Flag?", "red green blue", "white and yellow", 
			                                     "blue red gray", "green white red"));
				GameQuestionsList.Add(new Question_Object("Which was the leader of gods in greek mythology?", "Hades", "Isis", 
			                                     "Alcmene", "Zeus"));
				GameQuestionsList.Add(new Question_Object("\"Don't cry because it's over, smile because it happened\" is a quote said by:", "Mark Twain", "James Earl Jones", 
			                                     "J.R.R Tolkien", "Gabriel Garcia Marquez"));
				GameQuestionsList.Add(new Question_Object("Which of following artists are not singing rock music?", "Linkin Park", "Depeche Mode", 
			                                     "Nine Lashes", "Young London"));
				GameQuestionsList.Add(new Question_Object("Which was Hercule's most powerful enemy according greek mythology?", "Hades", "Poseidon", 
			                                     "Zeus", "Hera"));
				GameQuestionsList.Add(new Question_Object("How many senses does a human have?", "Only one", "Three", 
			                                     "Six", "Five"));
				GameQuestionsList.Add(new Question_Object("According to a saying what are these eyes?", "An universe", "A spark of light", 
			                                     "A diamond", "A mirror of soul"));
				GameQuestionsList.Add(new Question_Object("Who is the main character in Assasin's Creed game?", "Ezio Auditore", "Leonardo DaVinci", 
			                                     "Altair", "Desmond Miles"));
				GameQuestionsList.Add(new Question_Object("Which of the following is not a book?", "If Only It Were True", "Scarface", 
			                                     "The Lord Of The Rings", "Leon The Professional"));
				GameQuestionsList.Add(new Question_Object("Which of these created a popular detective character with the first name of \"Jane\"?", 
				                                          "John Le Carre", "P D James", "Patricia Cornwell", "Agatha Christie"));
				GameQuestionsList.Add(new Question_Object("What is the most frequent definition in mathematics of a straight line?", "Set of points", "Bi-Dimensional Quantity", 
			                                     "One-Dimensional Quantity", "None of them"));
				GameQuestionsList.Add(new Question_Object("Bamboo is the main diet of which of these animals??", "Koala", "Siberian Bear", 
			                                     "None of them", "Panda Bear"));
				GameQuestionsList.Add(new Question_Object("Traveling with speed of light. How far is our Earth from its sun?", "8.2 seconds", "4.1 minutes", 
			                                     "2 years", "8.1 minutes"));
				GameQuestionsList.Add(new Question_Object("The War of the Pacific 1879-1883 was fought where?", "West India", "New Zealand", 
			                                     "Western Australia", "Western South America"));
				GameQuestionsList.Add(new Question_Object("A swallowtail is a type of what?", "Firefly", "Deer", 
			                                     "Bird", "Butterfly"));
				GameQuestionsList.Add(new Question_Object("Which of these is not a member of the dog family?", "Wolf", "Fox", 
			                                     "Dingo", "Hyena"));
				GameQuestionsList.Add(new Question_Object("Where can a cactus be found?", "On a Mountain", "In the Garden", 
			                                     "Underwater", "In a Desert"));
				GameQuestionsList.Add(new Question_Object("Which was an Italian football player", "Campbell", "Serginho", 
			                                     "Pauleta", "Gattuso"));
				GameQuestionsList.Add(new Question_Object("What genre is the TV series \"Taggart\"?", "Travel", "Family", 
			                                     "Documentary", "Detective"));
				GameQuestionsList.Add(new Question_Object("Where would you find the metatarsal bone?", "Spine", "Skull", 
			                                     "Chest", "Foot"));
				GameQuestionsList.Add(new Question_Object("When was the chart-topping single \"Barbie Girl\" released?", "1992", "1995", 
			                                     "1999", "1997"));
				GameQuestionsList.Add(new Question_Object("The Gobi Desert lies in which area?", "Australia", "Afrika", 
				                                          "America", "Asia"));
				GameQuestionsList.Add(new Question_Object("Which sea surrounds the island of Martinique?", "Mediterranean", "Dead", 
			                                     "China", "Carribean"));
				GameQuestionsList.Add(new Question_Object("What is in a human's thoracic cavity?", "Pancreas", "Spleen", 
			                                     "Liver", "Lungs"));
				GameQuestionsList.Add(new Question_Object("About how much of the human body is composed of water?", "50 percent", "70 percent", 
			                                     "80 percent", "60 percent"));
				GameQuestionsList.Add(new Question_Object("Which mountain chain runs along the border between France and Spain?", "Passionfleas", "Pastemplease", 
			                                     "Manganesse", "Pyrenees"));
				GameQuestionsList.Add(new Question_Object("What is the meaning of the Spanish word \"mañana\"?", "Supermodel", "Yellow-skinned fruit", 
			                                     "Male aggresion", "Tomorrow"));
			}
			if(level>=10&&level<20)
			{
				GameQuestionsList.Add(new Question_Object("What is glass made of?", "Plastic", "Sugar", 
			                                     "Salt", "Sand"));
				GameQuestionsList.Add(new Question_Object("Which is a city that is situated on two different continents?", "Madrid", "Samsun", 
			                                     "Malatya", "Istambul"));
				GameQuestionsList.Add(new Question_Object("Who did Troy fought against?", "Persia", "Sparta", 
			                                     "Roman Imperium", "Greece"));
				GameQuestionsList.Add(new Question_Object("Which is the third world-wide biggest city?", "New York", "Tokio", 
			                                     "Cairo", "Beijing"));
				GameQuestionsList.Add(new Question_Object("Which of the following movies describe a love story?", "Where eagles dare", "Suspiria", 
			                                     "The Invisible", "Butterfly Effect"));
				GameQuestionsList.Add(new Question_Object("John Lennon has been part of the musical group called:", "Scorpions", "AC/DC",
			                                     "Queen", "The Beatles"));
				GameQuestionsList.Add(new Question_Object("What is an ISO?", "File Format", "File Group", 
			                                     "Programmers Organization", "A Standard"));
				GameQuestionsList.Add(new Question_Object("Where is AK-47 coming from?", "Turkey", "France", 
			                                     "USA", "Russia"));
				GameQuestionsList.Add(new Question_Object("Terminator is a science-fiction movie series that was directed by:", "Steven Spielberg", "Ridley Scott", 
			                                     "Adam Shankman", "James Cameroon"));
				GameQuestionsList.Add(new Question_Object("How many children did Einstein had?", "Only One", "Two", 
			                                     "None", "Three"));
				GameQuestionsList.Add(new Question_Object("Which of the follow is not a TV network?", "SciFi", "BBC", 
			                                     "Fox", "Nash"));
				GameQuestionsList.Add(new Question_Object("Which o following actors played Iron Man?", "Christian Bale", 
			                                     "Edward Norton","Hugh Jackman", "Robert Downey Jr"));
				GameQuestionsList.Add(new Question_Object("Who is Stephen King?", "An actor", "A director", 
			                                     "A serial killer", "A book writer"));
				GameQuestionsList.Add(new Question_Object("Which footballer has played on AC Milan?", "Tevez", "Bauptista", 
			                                     "Metzelder", "Cafu"));
				GameQuestionsList.Add(new Question_Object("Which of the following people invented a bulb?", "James Horner", "Pablo Pereira", 
			                                     "Bjarne Stroustroup", "Thomas Edison"));
				GameQuestionsList.Add(new Question_Object("Bear Grylls is an adventurer, author and speaker. But what is his nationality?", "Italian", "French", 
			                                     "American", "English"));
				GameQuestionsList.Add(new Question_Object("Which of the following is mythic creature?", "Scarecrow", "Cyclone", 
			                                     "Demon", "Hydra"));
				GameQuestionsList.Add(new Question_Object("Who formally became Emperor of Japan in 1926 and became its constitutional monarch in 1946?", 
				                                          "Akihito", "Taisho", "Tanisha", "Hirohito"));
				GameQuestionsList.Add(new Question_Object("What is not usually a phrase for which the acronym PDF is used?", 
				                                          "Planar Deformation Features", "Professional Drivers Foundation", "Portable Document Format", "Platform Drivers Float"));
				GameQuestionsList.Add(new Question_Object("Where would you meet the terms straight rail, cushion, balkline, artistic and cowboy?", "Pool", "Air Hokey", 
			                                     "Rodeor", "Carom Billiards"));
				GameQuestionsList.Add(new Question_Object("Who won the Women's Cricket World Cup played at Sydney, Australia, in 2009?", "New Zealand", "India", 
			                                     "Turkey", "England"));
				GameQuestionsList.Add(new Question_Object("What was Harry Potter's pet, Hedwig?", "Cat", "Dog", 
			                                     "Rat", "Owl"));
				GameQuestionsList.Add(new Question_Object("Which of these is a portmanteau word?", "Feet", "Boogie", 
			                                     "Gladstone Bag", "Smog"));
				GameQuestionsList.Add(new Question_Object("What is the main unit of currency in Turkey?", "Dollar", "Leu",
			                                     "Euro", "Lira"));
				GameQuestionsList.Add(new Question_Object("Who was the first person to refuse an Academy Award for Best Actor??", "Marlon Brando", "Peter Ustinov",
			                                     "Daniel Day Lewis", "George C Scott"));
				GameQuestionsList.Add(new Question_Object("What is the name for radiations of a wavelength shorter than, and immediately next to, the visible spectrum??", "Gamma", "Inflared", 
			                                     "X Rays", "Ultraviolet"));
				GameQuestionsList.Add(new Question_Object("Which of these is a country is on the continent of Africa?", "Bulimia", "Quadrophenia", 
			                                     "Brasilia", "Liberia"));
				GameQuestionsList.Add(new Question_Object("The last time that anyone spoke to Adolf Hitler, he was in what city??", "Rome", "Munchen",
			                                     "Frankfurt", "Berlin"));
				GameQuestionsList.Add(new Question_Object("Who formally became Emperor of Japan in 1926 and became its constitutional monarch in 1946?",
				                                          "Akihito", "Taisho", "Tanisha", "Hirohito"));
				GameQuestionsList.Add(new Question_Object("In December 2005, Amelle Berrabah became a member of which group??",
				                                          "Atomic Kitten", "Fleetwood Mac", "Pussycat Dolls", "Sugababes"));
				GameQuestionsList.Add(new Question_Object("What is the modern process used to make steel?",
				                                          "Bassemer", "Blooming", "Siemens-Martin", "Linz-Donawitz"));
				GameQuestionsList.Add(new Question_Object("Which football team won the World Cup in 1986?",
				                                          "Germany", "France", "Belgium", "Argentina"));
				GameQuestionsList.Add(new Question_Object("Who was Formula One Champion driver for 2013?",
				                                          "Susie Wolf", "Michael Schumacher", "Nico Rosberg", "Sebastian Vettel"));
				GameQuestionsList.Add(new Question_Object("Where does the dance called the \"tarantella\" have its roots?",
				                                          "Brazil", "Italy", "Spanish", "Greece"));
				GameQuestionsList.Add(new Question_Object("Usain Bolt is what type of athlete?",
				                                          "Swimmer", "High Jumper", "Boxer", "Sprinter"));
				GameQuestionsList.Add(new Question_Object("What in the human body shows the effect of melanin?",
				                                          "Liver", "Skin", "Lungs", "Heart"));
				GameQuestionsList.Add(new Question_Object("\"Things to do before you die\" was the subject of which 2007 film?",
				                                          "The Dead Pool", "My Name Is Earl", "Friends", "The Bucket List"));
				GameQuestionsList.Add(new Question_Object("In Western films, what is a bar regularly called??",
				                                          "Calaboose", "Bar", "Pokey", "Saloon"));
				GameQuestionsList.Add(new Question_Object("When did the Football Association in the UK present the FA Cup for competition?",
				                                          "1888", "1862", "1824", "1871"));
				GameQuestionsList.Add(new Question_Object("In which continent is the country of Gabon found?",
				                                          "Australia", "Europe", "Asia", "Afrika"));
				GameQuestionsList.Add(new Question_Object("The drug \"diazepam\" is used chiefly to what?",
				                                          "Reduce diabetes", "Reduce weight", "Reduce pain", "Reduce anxiety"));
				GameQuestionsList.Add(new Question_Object("Charlotte was the queen of which British king?",
				                                          "Edward VII", "Charles I", "William II", "George III"));
			}
			if(level>=20&& level<30)
			{
				GameQuestionsList.Add(new Question_Object("May the hair grow faster to people which are:?", "Younger", "Smarter", 
			                                     "Chiller", "Healther"));
				GameQuestionsList.Add(new Question_Object("When was the Lamborghini Manufacturer founded?", "1955", "1947", 
			                                     "1965", "1963"));
				GameQuestionsList.Add(new Question_Object("Elvis first single is owned by:", "Phille's Records", "Storyville Records", 
			                                     "Essex Records", "Sun Records"));
				GameQuestionsList.Add(new Question_Object("Which was the year of the titanic ship tragedy?", "1914", "1922", 
			                                     "1911", "1912"));
				GameQuestionsList.Add(new Question_Object("When was the first modern car produced?", "1889", "1877", 
			                                     "1885", "1886"));
				GameQuestionsList.Add(new Question_Object("Waterworld is a movie from 1986, which of the following has acted into it?", "Mat Kearney", "Anthony Hopkins", 
			                                     "Demi Moore", "Kevin Costner"));
				GameQuestionsList.Add(new Question_Object("E.T is a sci-fi movie directed by:", "James Cameroon", "Robert Zemechis", 
			                                     "Stephen King", "Steven Spielberg"));
				GameQuestionsList.Add(new Question_Object("What is Aurora?", "Media Anomaly", "Star Falling", 
			                                     "Light Refraction", "Just a phenomenon"));
				GameQuestionsList.Add(new Question_Object("An elf is mythic creature, from which mythology?", "Roman", "Greece", 
			                                     "Norse", "German"));
				GameQuestionsList.Add(new Question_Object("In which year was founded the first football league?", "1878", "1892", 
			                                     "1882", "1888"));
				GameQuestionsList.Add(new Question_Object("Where did J.R.R Tolkien studied?", "Harvard University", "Cambridge University", 
			                                     "Stanford University", "Oxford University"));
				GameQuestionsList.Add(new Question_Object("What did Bjarne Stroustroup invented?", "Game", "Gouvernamental System", 
			                                     "Electronic Circuit", "Programming Language"));
				GameQuestionsList.Add(new Question_Object("Pattaya is a city in:", "Egypt", "Saudi Arabia", 
			                                     "Ethiopia", "Thailand"));
				GameQuestionsList.Add(new Question_Object("The development of C programming language took an amount of: ", "8 years", "5 years", 
			                                     "3 years", "4 years"));
				GameQuestionsList.Add(new Question_Object("USA 38th president was: ", "George W. Bush", "Jimmy Carter", 
			                                     "Richard Nixon", "Gerald Ford"));
				GameQuestionsList.Add(new Question_Object("How many brothers did Nikola Tesla had?", "two", "five", 
			                                     "none", "four"));
				GameQuestionsList.Add(new Question_Object("Who won the 1984 Nobel Peace Prize?", "Lech Walesa", "F.W DeClerk", 
			                                     "Nelson Mandela", "Desmond Tutu"));
				GameQuestionsList.Add(new Question_Object("Ron Hubbard is known as the founder of what movement?", "Unification Church", "Church of Jesus Christ", 
			                                     "Salvation Army", "Scientology"));
				GameQuestionsList.Add(new Question_Object("Franklin Roosevelt was fairly fluent in which languages other than English?", "Romanian and Greek", "French and Italian", 
			                                     "Polish and Russian", "German and French"));
				GameQuestionsList.Add(new Question_Object("How many poles are there related to the planet Earth??", "Two", "Four", 
			                                     "Only One", "Ten"));
				GameQuestionsList.Add(new Question_Object("What type of beer takes its name from the German word for \"storage\"?", "Dunkel", "Bock", 
			                                     "Pilner", "Lager"));
				GameQuestionsList.Add(new Question_Object("Frederic Chopin is best known for his compositions for which instrument??", "Percussion", "Accordion", 
			                                     "Guitar", "Piano"));
				GameQuestionsList.Add(new Question_Object("Robert de Vere was an advisor and companion to which English king?", "Edward II", "William II", 
			                                     "William I", "Richard II"));
				GameQuestionsList.Add(new Question_Object("What is the plural of \"criteria\"??", "Criterion", "Criterias",
			                                     "Criterae", "None of them"));
				GameQuestionsList.Add(new Question_Object("When was the football club now known as Manchester United first formed?", "1882", "1872", 
			                                     "1888", "1878"));
				GameQuestionsList.Add(new Question_Object("Which college was founded by Henry VI in 1440?", "Chatterhouse", "King's College", 
			                                     "Harrow", "Eton"));
				GameQuestionsList.Add(new Question_Object("Bondi Beach is a suburb of which city??", "Rio de Janneiro", "Barcelona", 
			                                     "Cape Town", "Sydney"));
				GameQuestionsList.Add(new Question_Object("If a Greek person calls \"Eureka\" what are they saying?", "Out of the way", "Hold on", 
			                                     "No brakes", "I found it"));
				GameQuestionsList.Add(new Question_Object("Where was freestyle swimming first developed?", "New Zealand", "Mexico", 
			                                     "China", "Australia"));
				GameQuestionsList.Add(new Question_Object("What is the longest river in the world?", "Rhine", "Congo",
			                                     "Amazon", "Nile"));
				GameQuestionsList.Add(new Question_Object("What chess piece is also called a \"castle\"?", "Queen", "Shag", 
			                                     "Crow", "Rook"));
				GameQuestionsList.Add(new Question_Object("What is an earlier name for the city of Harare?", "Rome", "Athens", 
			                                     "Lagos", "Salisbury"));
				GameQuestionsList.Add(new Question_Object("As at 2014 how many sports are contested in the Winter Paralympics?", "4", "20", 
			                                     "45", "5"));
				GameQuestionsList.Add(new Question_Object("Harvard University is in which state of the USA?", "Rhode Island", "Connecticut", 
			                                     "Maine", "Massachusetts"));
				GameQuestionsList.Add(new Question_Object("Which of following actors is the eldest?", "Sean Connery", "Nicholas Cage", 
			                                     "Clint Eastwood", "Gene Hackman"));
				GameQuestionsList.Add(new Question_Object("Who was the first person to win both an Oscar and a Nobel Prize?", "Robert Louis Stevenson", "Sheridan Gibney",
			                                     "Harold Pinter", "George Bernard Shaw"));
			}
			if(level>=30)
			{
				GameQuestionsList.Add(new Question_Object("A Canadian-American adventure and military scifi TV series which first screened in 1997 " +
				                                          "was one of the longest lasting. What was it called?", "Big Bang Theory",
			                                     "Atlantis", "24", "Stargate SG-1"));
				GameQuestionsList.Add(new Question_Object("What word would you use to describe someone who sees sound?", "Syncretist", "Syncronous", 
			                                     "Synthesiser", "Synaesthesia"));
				GameQuestionsList.Add(new Question_Object("In which century was the Suez Canal opened?", "15th", "20th", 
			                                     "17th", "19th"));
				GameQuestionsList.Add(new Question_Object("Which figure from Scottish history was played by Mel Gibson in a 1995 film?", "Robbie Burns", "Prince Charlie", 
			                                     "Alexander Fleming", "William Wallace"));
				GameQuestionsList.Add(new Question_Object("Entomology is the study of what?", "Birds", "Maps", 
			                                     "Words", "Insects"));
				GameQuestionsList.Add(new Question_Object("What musical instruments does a luthier work with?", "Piano", "Percussion", 
			                                     "Wind", "Stringed"));
				GameQuestionsList.Add(new Question_Object("How many legs has an arachnid?", "6", "10", 
			                                     "12", "8"));
				GameQuestionsList.Add(new Question_Object("In 1946, what did the USA offer to buy for $100,000,000?", "Alaska", "Iceland",
			                                     "Part of Ontario", "Greenland"));
				GameQuestionsList.Add(new Question_Object("The first modern Olympic games as we currently know them were held in which century?", "20th", "15th", 
			                                     "17th", "19th"));
				GameQuestionsList.Add(new Question_Object("To which part of the world are the Zulu people native?", "Southern Afrika", "Australia", 
			                                     "Middle East", "Southern America"));
				GameQuestionsList.Add(new Question_Object("Where was the playwright August Strindberg born?", "Switchzerland", "Norway", 
			                                     "Denmark", "Sweden"));
				GameQuestionsList.Add(new Question_Object("\"I'm a dot in place\" has what relation to \"A decimal point\"?", "Polindrome", "Pun", 
			                                     "Polinom", "Anagram"));
				GameQuestionsList.Add(new Question_Object("According to Forbes as at June 2014, which is the second richest football club in the world?", "Bayern Munchen", "Atletico Madrid", 
			                                     "Real Madrid", "Barcelona"));
				GameQuestionsList.Add(new Question_Object("In which country was there a civil war between 1936 and 1939, which was won by General Franco's forces?", "France", "Brasil", 
			                                     "Portugal", "Spain"));
				GameQuestionsList.Add(new Question_Object("Which of these is a character in \"The Matrix\" series of films?", "Patrick A. Anderson", "Nigel Stanford", 
			                                     "Richard Dean Anderson", "Thomas A Anderson"));
				GameQuestionsList.Add(new Question_Object("The Three Gorges Dam is in which country?", "SUA", "Mexico", 
			                                     "Japan", "China"));
				GameQuestionsList.Add(new Question_Object("Which of these is tallest?", "Brad Pitt", "Tom Cruise", 
			                                     "Danny de Vito", "Clint Eastwood"));
				GameQuestionsList.Add(new Question_Object("What is kept in the sump of a motor car engine?", "Water", "Gas", 
			                                     "Petrol", "Oil"));
				GameQuestionsList.Add(new Question_Object("Which are the other names of Al Pacino?", "Sean George", "Alfred George", 
			                                     "James Alan", "Alfredo James"));
				GameQuestionsList.Add(new Question_Object("What is Patrick Swayze doing?", "Playing cards", "Playing football", 
			                                     "Acting Theatre", "Acting Movies"));
				GameQuestionsList.Add(new Question_Object("Which of these movies is from 1990?", "The Terminator", "Rambo", 
			                                     "E.T The Extraterestrial", "Ghost"));
				GameQuestionsList.Add(new Question_Object("Which actor is playing Wolverine in X-men Movies?", "Bryan Singer", "Stan Lee", 
			                                     "Gene Hackman", "Hugh Jackham"));
				GameQuestionsList.Add(new Question_Object("Which of these films was set in in World War II ?", "The Quiet American", "The Ugly American", 
			                                     "Coming Home", "I Was Monty's Double"));
				GameQuestionsList.Add(new Question_Object("What instrument is used for measuring relative humidity?", "Hypsometer", "Micrometer", 
			                                     "Multimeter", "Hygrometer"));
				GameQuestionsList.Add(new Question_Object("Which of these is the study of reptiles?", "Batology", "Batophobia", 
			                                     "Battology", "Batrachology"));
				GameQuestionsList.Add(new Question_Object("When was the Euro first used as a unit of currency?", "1997", "1998", 
			                                     "2000", "1999"));
				GameQuestionsList.Add(new Question_Object("Which of these models was born in Australia?", "Naomi Campbell", "Cindy Crowford", 
			                                     "Claudia Schiffer", "Ellie MacPherson"));
				GameQuestionsList.Add(new Question_Object("In which film did Johnny Depp play a policeman called Ichabod Crane?", "The Mask", "88 Minutes", 
			                                     "Secret Widow", "Sleepy Hallow"));
				GameQuestionsList.Add(new Question_Object("What is the capital of the state of North Dakota, USA?", "Sioux Fall", "Fargo", 
			                                     "Pierre", "Bismarck"));
				GameQuestionsList.Add(new Question_Object("Amortisation is similar to?", "Bevelling", "Embalming", 
			                                     "Marriage", "Depreciation"));
				GameQuestionsList.Add(new Question_Object("Where in Africa is Table Mountain?", "Egypt", "Marocco", 
			                                     "Libya", "Southern Afrika"));
				GameQuestionsList.Add(new Question_Object("What is the movie Black Hawk Down about?", "Civil War", "World War", 
			                                     "Vietnam War", "Modern War"));
				GameQuestionsList.Add(new Question_Object("Which of these minerals is used in the manufacture of eyeliner?", "Kaolin", "Coal", 
			                                     "Carbon", "Kohl"));
				GameQuestionsList.Add(new Question_Object("Who is the youngest actor to receive an Oscar for the Best Actor in a Leading Role??", "Marlon Brando", "Nicholas Cage", 
			                                     "Richard Dreyfuss", "Adrien Body"));
				GameQuestionsList.Add(new Question_Object("What is the next country in the list: Djibouti, Zimbabwe, Namibia, Eritrea ...?", "Somalia", "Ethiopia", 
			                                     "Egypt", "South Sudan"));
				GameQuestionsList.Add(new Question_Object("In the digital world what does the \"V\" stand for in \"VR\"?", "Very", "Voltage", 
			                                     "Battology", "Virtual"));
				GameQuestionsList.Add(new Question_Object("What chain of islands stretches from the Netherlands to Denmark?", "Friendly Islands", "Channel Islands", 
			                                     "Feroe Islands", "Frisian Islands"));
				GameQuestionsList.Add(new Question_Object("Ogen and cantaloupe are types of what?", "Orange", "Bannana", 
			                                     "Pear", "Melon"));
				GameQuestionsList.Add(new Question_Object("Who wrote the main theme for Lord Of The Rings movie?", "James Horner", "Conjure One", 
			                                     "Jesper Kyd", "Howard Shore"));
				GameQuestionsList.Add(new Question_Object("What is another name for \"laughing gas\"?", "Krypton", "Gasoline", 
			                                     "Battology", "Batrachology"));
				GameQuestionsList.Add(new Question_Object("Which of these is the study of reptiles?", "Batology", "Batophobia", 
			                                     "Hidrogen Sulphide", "Nitrous Oxide"));
				GameQuestionsList.Add(new Question_Object("Which of the following does not produce an oscilation due to wind?", "String", "Bow", 
			                                     "Pendulum", "Fixed stone"));
				GameQuestionsList.Add(new Question_Object("Which of these people is concerned with the study of gorillas?", "Diana Wheeler", "Diana Keyton", 
			                                     "Diana Rigg", "Diane Fossey"));
				GameQuestionsList.Add(new Question_Object("Seas and oceans make up roughly what proportion of the earth's surface?", "50", "90", 
			                                     "80", "70"));
				GameQuestionsList.Add(new Question_Object("Which Latin poet wrote \"Satires\", \"Epodes\", \"Epistles\" and \"Carmen Seculare\"?", "Horner", "Homer", 
			                                     "Maecenes", "Horace"));
				GameQuestionsList.Add(new Question_Object("Gibbons are mostly native to which continent?", "America", "Australia", 
			                                     "Afrika", "Asia"));
				GameQuestionsList.Add(new Question_Object("Which film features a large green, earwax-eating \"hero\"?", "Green Lantern", "Green Homet", 
			                                     "Ant Man", "Shrek"));
				GameQuestionsList.Add(new Question_Object("Which of these places in England is the most northerly?", "Maidstone", "Milton Keynes", 
			                                     "Manchester", "Middlesbrough"));
				GameQuestionsList.Add(new Question_Object("Which of these drinks is a variety of sherry?", "Vanilla", "Monbasa", 
			                                     "Beeper", "Manzanilla"));
				GameQuestionsList.Add(new Question_Object("What does the Russian word \"Sputnik\" mean?", "Friendly foe", "Circle", 
			                                     "80", "Fellow traveller"));
				GameQuestionsList.Add(new Question_Object("Which of these planets is known for its rings?", "Earth", "Mercury", 
			                                     "March", "Saturn"));
				GameQuestionsList.Add(new Question_Object("What sort of animal is the character created for children called \"Blinky Bill\"?", 
				                                          "Wombat", "Barn Owl", "Panda", "Koala"));
				GameQuestionsList.Add(new Question_Object("A musical instruction to treat the piece of music \"pizzicato\" means to do what?", "Hit Hard", "Blow Continuosly", 
			                                     "Play boisterously", "Pluck"));
				GameQuestionsList.Add(new Question_Object("In darts, what is the name of the line behind which the throwing player must stand??", "Jack", "Chukka", 
			                                     "Char", "Oche"));
				GameQuestionsList.Add(new Question_Object("Bondi Beach is near which city?", "Hawaii", "Naples", 
			                                     "San Francisco", "Sydney"));
				GameQuestionsList.Add(new Question_Object("What attaches muscles to bone?", "Ligaments", "Marrow", 
			                                     "Arters", "Tendons"));
				GameQuestionsList.Add(new Question_Object("Which of these capitals is the most northern?", "Ottawa", "Moscow", 
			                                     "Oslo", "Reikjavik"));
				GameQuestionsList.Add(new Question_Object("Which of these sports uses a round ball?", "Australian Football", "American Football", 
			                                     "Rugby", "Volleyball"));
				GameQuestionsList.Add(new Question_Object("Where is the volcanic Tibesti mountain range?", "Argentina", "Italia", 
			                                     "Tibet", "Sahara"));
				GameQuestionsList.Add(new Question_Object("What is the name of the mascot for the cereal Cocoa Puffs?", "Cuckoo", "Chocko", 
			                                     "Puffin", "Sonny"));
			}
		}
		public static void ItemShop(ref uint money, ref uint multiplier, ref uint chances, ref uint NrOfAnswears)
		{
			if(money>=5000)
			{
				string optionChoice;
				Console.WriteLine("\n######################\nSHOP MENU\n####################");
				Console.WriteLine("Money: {0}$\n", money);
				Console.WriteLine("Option		Package		Price");
				Console.WriteLine("1.		1xChance	5000$");
				Console.WriteLine("2.		2xChance	9000$");
				Console.WriteLine("3.		3xChance	13000$");
				Console.WriteLine("4.	X2MoneyMultiplier	500000$");
				Console.WriteLine("5.	X3MoneyMultiplier	1500000$");
				Console.WriteLine("6. 	X4MoneyMultiplier	5000000$");
				Console.WriteLine("7. 	3AnswearQuestions	10000000$");
				Console.WriteLine("8. 	2AnswearQuestions	25000000$");
				Console.WriteLine("\nPress Q to quit the shop!");
				Console.WriteLine("\nWhat is your option?");
				optionChoice=Convert.ToString(Console.ReadLine());
				while(optionChoice!="1" && optionChoice!="2" && optionChoice!="3" && optionChoice!="4" && optionChoice!="5" 
				      && optionChoice!="6" && optionChoice!="7" && optionChoice!="8" && optionChoice.ToUpper()!="Q")
				{
					Console.WriteLine("Please answear only with one of the options!");
					optionChoice=Convert.ToString(Console.ReadLine());
				}
				if(optionChoice=="1"&&money>=5000)
				{
					money-=5000;
					chances+=1;
				}
				else if(optionChoice=="2"&&money>=9000)
				{
					money-=9000;
					chances+=2;
				}
				else if(optionChoice=="3"&&money>=13000)
				{
					money-=13000;
					chances+=3;
				}
				else if(optionChoice=="4"&&money>=500000)
				{
					if(multiplier>=2)
					{
						Console.WriteLine("You cannot buy this pachage anymore. You either have it, or a better one.");
					}
					else
					{
						money-=500000;
						multiplier=2;
					}
				}
				else if(optionChoice=="5"&&money>=1500000)
				{
					if(multiplier>=3)
					{
						Console.WriteLine("You cannot buy this pachage anymore. You either have it, or a better one.");
					}
					else
					{
						money-=1500000;
						multiplier=3;
					}
				}
				else if(optionChoice=="6"&&money>=5000000)
				{
					if(multiplier>=4)
					{
						Console.WriteLine("You cannot buy this pachage anymore. You either have it, or a better one.");
					}
					else
					{
						money-=5000000;
						multiplier=4;
					}
				}
				else if(optionChoice=="7"&&money>=10000000)
				{
					if(NrOfAnswears>3)
					{
						money-=10000000;
						NrOfAnswears=3;
					}
					else
					{
						Console.WriteLine("You cannot buy this pachage anymore. You either have it, or a better one.");
					}
				}
				else if(optionChoice=="8"&&money>=25000000)
				{
					if(NrOfAnswears>2)
					{
						money-=25000000;
						NrOfAnswears=2;
					}
					else
					{
						Console.WriteLine("You cannot buy this pachage anymore. You either have it, or a better one.");
					}
				}
				else if(optionChoice.ToUpper()=="Q")
				{
					Console.WriteLine("You have quit the Item Shop!");
				}
				else
				{
					Console.WriteLine("You don't have enough money for that option!");
					Console.WriteLine("Press any key to resume the game!");
					Console.ReadKey(true);
				}
				Console.Clear();
			}
		}
		public static void GetHighestScore(ref string Highscore)
		{
			Highscore="No present Data";
			
			if(System.IO.File.Exists(path))
			{
				if(System.IO.File.ReadAllText(path)!="")
				{
					Highscore=System.IO.File.ReadAllText(path);
				}
			}
		}
		public static void SetANewHighScore(string HighScore, uint money, out string newHighScore)
		{
			newHighScore=HighScore;
			if(HighScore!="No present Data")
			{
				if(money>Convert.ToUInt32(HighScore))
				{
					newHighScore=Convert.ToString(money);
				}
			}
		}
		public static void SaveScore(uint money, string highscore)
		{
			if(highscore!="No present Data")
			{
				if(money>Convert.ToInt32(highscore))
				{
					System.IO.File.WriteAllText(path, Convert.ToString(money));
				}
			}
			else
			{
				System.IO.File.WriteAllText(path, Convert.ToString(money));
			}
		}
	}
	class Question_Object
	{
		string question;
		string answearVar1;
		string answearVar2;
		string answearVar3;
		string CorrectAnswear;
		string CorrectAnswearChar;
		public Question_Object(string newQuestion, string answear1, string answear2, string answear3, string GivenCorrectAnswear)
		{
			question = newQuestion;
			answearVar1 = answear1;
			answearVar2 = answear2;
			answearVar3 = answear3;
			CorrectAnswear = GivenCorrectAnswear;
		}
		public void PrintQuestion()
		{
			Console.WriteLine("Question: {0}\n", question);
		}
		public void PrintAnswears()
		{
			Random getPosition = new Random();
			int i = getPosition.Next(1,25);
			if(i==1)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar1, answearVar2, answearVar3); CorrectAnswearChar="A";}
			if(i==2)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar1, answearVar3, answearVar2); CorrectAnswearChar="A";}
			if(i==3)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar2, answearVar1, answearVar3); CorrectAnswearChar="A";}
			if(i==4)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar2, answearVar3, answearVar1); CorrectAnswearChar="A";}
			if(i==5)	
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar3, answearVar2, answearVar1); CorrectAnswearChar="A";}
			if(i==6)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", CorrectAnswear, answearVar3, answearVar1, answearVar2); CorrectAnswearChar="A";}
			if(i==7)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, CorrectAnswear, answearVar2, answearVar3); CorrectAnswearChar="B";}
			if(i==8)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, CorrectAnswear, answearVar3, answearVar2); CorrectAnswearChar="B";}
			if(i==9)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, answearVar2, CorrectAnswear, answearVar3); CorrectAnswearChar="C";}
			if(i==10)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, answearVar3, CorrectAnswear, answearVar2); CorrectAnswearChar="C";}
			if(i==11)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, answearVar3, answearVar2, CorrectAnswear); CorrectAnswearChar="D";}
			if(i==12)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar1, answearVar2, answearVar3, CorrectAnswear); CorrectAnswearChar="D";}
			if(i==13)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, CorrectAnswear, answearVar1, answearVar3); CorrectAnswearChar="B";}
			if(i==14)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, CorrectAnswear, answearVar3, answearVar1); CorrectAnswearChar="B";}
			if(i==15)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, answearVar1, CorrectAnswear, answearVar3); CorrectAnswearChar="C";}
			if(i==16)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, answearVar3, CorrectAnswear, answearVar1); CorrectAnswearChar="C";}
			if(i==17)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, answearVar1, answearVar3, CorrectAnswear); CorrectAnswearChar="D";}
			if(i==18)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar2, answearVar3, answearVar1, CorrectAnswear); CorrectAnswearChar="D";}
			if(i==19)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, CorrectAnswear, answearVar1, answearVar2); CorrectAnswearChar="B";}
			if(i==20)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, CorrectAnswear, answearVar2, answearVar1); CorrectAnswearChar="B";}
			if(i==21)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, answearVar2, CorrectAnswear, answearVar1); CorrectAnswearChar="C";}
			if(i==22)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, answearVar1, CorrectAnswear, answearVar2); CorrectAnswearChar="C";}
			if(i==23)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, answearVar2, answearVar1, CorrectAnswear); CorrectAnswearChar="D";}
			if(i==24)
			{Console.WriteLine("A.{0}		B.{1}		C.{2}		D.{3}", answearVar3, answearVar1, answearVar2, CorrectAnswear); CorrectAnswearChar="D";}
		}
		public bool CheckCorrectAnswear(string answear, uint level, uint oldmoney, uint multiplier, ref bool EnterItemShop, out uint newmoney)
		{
			newmoney=oldmoney;
			if(answear.ToUpper()==CorrectAnswear.ToUpper() || answear.ToUpper()==CorrectAnswearChar)
			{
				if(level<10)
				{
					newmoney = level*500*multiplier+oldmoney;
				
				}
				else if(level>=10 && level<20)
				{
					newmoney = level*1000*multiplier+oldmoney;
				}
				else if(level>=20 && level<30)
				{
					newmoney = level*5000*multiplier+oldmoney;
				}
				else if(level>=30 && level<40)
				{
					newmoney = level*10000*multiplier+oldmoney;
				}
				//Just in case:
				else if(level>=40)
				{
					newmoney = level*20000*multiplier+oldmoney;
				}
				Console.WriteLine("You won: {0}$", newmoney-oldmoney);
				Console.WriteLine("\nPress a key: \n");
				if(newmoney>=5000)
				{
					Console.WriteLine("B -> Open the Item Shop");
				}
				Console.WriteLine("Any other key to resume!");
				string ShopAnswear = Convert.ToString(Console.ReadLine());
				if(ShopAnswear.ToUpper() == "B" && newmoney>=5000)
				{
					EnterItemShop=true;
				}
				else
				{
					EnterItemShop=false;
				}
				Console.Clear();
				return true;
			}
			return false;
		}
		public void PrintSpecialAnswears2(ref string BadAnswearVar)
		{
			Random i = new Random();
			int takechoice = i.Next(1,4);
			if(takechoice==1)
			{
				BadAnswearVar=answearVar1;
			}
			else if(takechoice==2)
			{
				BadAnswearVar=answearVar2;
			}
			else
			{
				BadAnswearVar=answearVar3;
			}
			int DecidePrintingOrder = i.Next(1,3);
			if(DecidePrintingOrder==1)
			{
				Console.WriteLine("A.{0}		B.{1}", CorrectAnswear, BadAnswearVar);
				CorrectAnswearChar="A";
			}
			else
			{
				Console.WriteLine("A.{0}		B.{1}", BadAnswearVar, CorrectAnswear);
				CorrectAnswearChar="B";
			}
		}
		public void PrintSpecialAnswears3(ref string BadAnswearVar1, ref string BadAnswearVar2)
		{
			Random i = new Random();
			int takechoice = i.Next(1,4);
			if(takechoice==1)
			{
				BadAnswearVar1=answearVar1;
				BadAnswearVar2=answearVar2;
			}
			else if(takechoice==2)
			{
				BadAnswearVar1=answearVar1;
				BadAnswearVar2=answearVar3;
			}
			else
			{
				BadAnswearVar1=answearVar2;
				BadAnswearVar2=answearVar3;
			}
			int DecidePrintingOrder = i.Next(1,7);
			if(DecidePrintingOrder==1)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", CorrectAnswear, BadAnswearVar1, BadAnswearVar2);
				CorrectAnswearChar="A";
			}
			else if(DecidePrintingOrder==2)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", CorrectAnswear, BadAnswearVar2, BadAnswearVar1);
				CorrectAnswearChar="A";
			}
			else if(DecidePrintingOrder==3)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", BadAnswearVar1, CorrectAnswear, BadAnswearVar2);
				CorrectAnswearChar="B";
			}
			else if(DecidePrintingOrder==4)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", BadAnswearVar2, CorrectAnswear, BadAnswearVar1);
				CorrectAnswearChar="B";
			}
			else if(DecidePrintingOrder==5)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", BadAnswearVar1, BadAnswearVar2, CorrectAnswear);
				CorrectAnswearChar="C";
			}
			else if(DecidePrintingOrder==6)
			{
				Console.WriteLine("A.{0}		B.{1}		C.{2}", BadAnswearVar2, BadAnswearVar1, CorrectAnswear);
				CorrectAnswearChar="C";
			}
		}
		//Getters:
		public string GetCorrectAnswear()
		{
			return CorrectAnswear;
		}
		public string GetAnswear1()
		{
			return answearVar1;
		}
		public string GetAnswear2()
		{
			return answearVar2;
		}
		public string GetAnswear3()
		{
			return answearVar3;
		}
	}
}