using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnagramGame
{
    public partial class Form1 : Form
    {
        public string user_input = "";
        //Use this for levels.
        List<Anagrams> Game = new List<Anagrams> { };
        uint level = 1;
        bool gameover = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Suspending Old Controls:
            this.button2.Dispose(); //Destroy button2 (Quit);
            this.button1.Dispose(); //Destroy button1 (Start Game);
            this.button1.SuspendLayout();
            this.button2.SuspendLayout();

            //Adding those controls:
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button4);
            this.BackgroundImage = global::AnagramGame.Properties.Resources.Green_Light_Keyboard_Macro_Wallpaper_Desktop;
            //Adding levels:
            Game.Add(new Anagrams("SRKENADS", "DARKNESS", "It comes once with the night!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("WMTORORO", "TOMORROW", "It comes in future!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("DNGRUNDOUER", "UNDERGROUND", "Its placed below the surface!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("MNETRTPAA", "APARTMENT", "A place to stay!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("TNOCELRACAEI", "ACCELERATION", "Force of a car!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("SERPEDISNO", "DEPRESSION", "Excessive sadness!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("NTLGENCEINIEL", "INTELLIGENCE", "Power of the brain!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("DTONRAYCII", "DICTIONARY", "A book full of words!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("WUNDTREAER", "UNDERWATER", "A place where fish can live!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("RANORMSTBI", "BRAINSTORM", "An idea that comes suddenly!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("MTHACITAEMS", "MATHEMATICS", "Difficult field of study!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("NLOGTYCHEO", "TECHNOLOGY", "Something that is related to engineering!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("SUTAHLOCO", "HOLOCAUST", "A mass of destruction!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("PRGRMIGNOMA", "PROGRAMMING", "Language used by computers!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("RCSADORSO", "CROSSROAD", "Ways meeting up together!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("LMOGRABHIIN", "LAMBORGHINI", "Fast and expensive car!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("WPOHRSEROE", "HORSEPOWER", "Force that makes a car able to fly!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("PREGOEKAEL", "GOALKEEPER", "Possition on a footbal team!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("LNDSAPCAE", "LANDSCAPE", "Something that's seen in a picture!", (uint)Game.Count + 1));
            Game.Add(new Anagrams("AMIONHCIPSPI", "CHAMPIONSHIP", "A big competition!", (uint)Game.Count + 1));
            textBox5.Text = Game[(int)level-1].GetChances().ToString();
            textBox8.Text = (level-1).ToString();
            textBox6.Text = Game[(int)level-1].GetInfoClue();
            textBox4.Text = Game[(int)level-1].GetAnagram();
            button3.Click += new EventHandler(this.button3_Click); // using this to call the function button3 when it is clicked.
            //textBox7.KeyDown += new KeyEventHandler(Send);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                user_input = textBox7.Text.ToUpper();
                textBox7.Text = "";
                if(Game[(int)level-1].CheckAnswear(user_input, ref level))
                {
                    textBox9.Text = "Good answear!";
                    textBox7.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    if(level==21)
                    {
                        textBox9.Text = "Congratulations!";
                        button4.Text = "End Program";
                        gameover = true;
                    }
                    button4.Click += new EventHandler(this.button4_Click);
                }
                else
                {
                    textBox9.Text = "Bad answear!";
                    textBox5.Text = Game[(int)level - 1].GetChances().ToString();
                    if(Game[(int)level-1].GetChances()<=0)
                        {
                            textBox9.Text = "GameOver!";
                            button4.Enabled = true;
                            button4.Text = "Quit";
                            gameover = true;
                            button4.Click += new EventHandler(this.button4_Click);
                        }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!gameover)
            {
                textBox5.Text = Game[(int)level - 1].GetChances().ToString();
                textBox8.Text = (level - 1).ToString();
                textBox6.Text = Game[(int)level - 1].GetInfoClue();
                textBox4.Text = Game[(int)level - 1].GetAnagram();
                button3.Click += new EventHandler(this.button3_Click);
                button4.Enabled = false;
                textBox9.Text = "";
                textBox7.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
        }
        private void Send(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                user_input = textBox7.Text;
                //textBox7.Text = "";
            }
        }
    }
    public class Anagrams
    {
        string anagram;
        uint level;
        string solution;
        string info;
        uint chances;
        public Anagrams(string Anagram_Word, string Solution_Word, string Information, uint Level_Value)
        {
            anagram = Anagram_Word;
            level = Level_Value;
            solution = Solution_Word;
            info = Information;
            chances = 10;
        }
        public bool CheckAnswear(string UserAnswear, ref uint level)
        {
            if (UserAnswear.ToUpper() == this.solution)
            {
                level++;
                return true;
            }
            else
            {
                this.chances--;
                return false;
            }
        }
        public uint GetLevel()
		{
            return this.level ;
		}
        public uint GetChances()
		{
            return this.chances ;
		}
        public string GetInfoClue()
		{
            return this.info;
		}
        public string GetAnagram()
        {
            return this.anagram;
        }
    }
}
