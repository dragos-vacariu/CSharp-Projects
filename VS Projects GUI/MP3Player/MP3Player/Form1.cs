using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace MP3Player
{
    public partial class Form1 : Form
    {
        bool RepeatMode = false;
        string path = @"D:/playlist.txt";
        public string fileToOpen;
        WMPLib.WindowsMediaPlayer wmplayer = new WMPLib.WindowsMediaPlayer();
        List<string> Playlist = new List<string>{};
        public Form1()
        {
            InitializeComponent();
            ReadVirtualList();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Text = "Pause";
            if (fileToOpen != null && fileToOpen.EndsWith(".mp3"))
            {
                wmplayer.URL = fileToOpen;
                wmplayer.controls.play();
                textBox1.Text = "Playing " + fileToOpen;
            }
            else if (fileToOpen == null)
            {
                textBox1.Text = "No file has been selected!";
            }
            else if(!fileToOpen.EndsWith(".mp3"))
            {
                textBox1.Text = "Your file cannot be played!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileToOpen = FD.FileName;
                if (!fileToOpen.EndsWith(".mp3"))
                {
                    textBox1.Text = "Your file cannot be played!";
                }
                else
                {
                    textBox1.Text = "File selected: " + fileToOpen;
                } 
               //System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                //OR

                //System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double position = wmplayer.controls.currentPosition;
            if(wmplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                wmplayer.controls.pause();
                position = wmplayer.controls.currentPosition;
                textBox1.Text = "Curently Paused On: " + fileToOpen;
                button3.Text = "Resume";
            }
            else if (wmplayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                wmplayer.controls.play();
                wmplayer.controls.currentPosition = position;
                textBox1.Text = "Playing " + fileToOpen;
                button3.Text = "Pause";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fileToOpen != null && fileToOpen.EndsWith(".mp3"))
            {
                if (!PlaylistContainsFile())
                {
                    System.IO.File.WriteAllText(path, GetContent() + fileToOpen + "@" +Environment.NewLine);
                    //Environment.NewLine will add a new line in the written file.
                    textBox1.Text = "File: " + fileToOpen + " was added to the playlist.";
                    Playlist.Add(fileToOpen);
                }
            }
            else
            {
                textBox1.Text = "You need to select a valid file.";
            }
        }
        public bool PlaylistContainsFile()
        {
            string content = "";
            if(System.IO.File.Exists(path))
            {
                content = System.IO.File.ReadAllText(path);
                if(content.Contains(fileToOpen))
                {
                    textBox1.Text = "The selected file is already in the playlist.";
                    return true;
                }
            }
            return false;
        }
        public string GetContent()
        {
            if (System.IO.File.Exists(path))
            {
                string content = System.IO.File.ReadAllText(path);
                content += "\n";
                return content;
            }
            return "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(Playlist.Count == 0)
            {
                ReadVirtualList();
            }
            else
            {
                fileToOpen = GetNextChoice();
                wmplayer.URL = fileToOpen;
                wmplayer.controls.play();
                textBox1.Text = textBox1.Text = "Playing " + fileToOpen;

            }
        }
        private string GetNextChoice()
        {
            foreach(string k in Playlist)
            {
                if(k == fileToOpen)
                {
                    if(Playlist.IndexOf(k)<Playlist.Count-1)
                    {
                        return Playlist[Playlist.IndexOf(k) + 1];
                    }
                    else
                    {
                        return Playlist[0];
                    }
                }
            }
            return Playlist[0]; //this should never be reached
        }
        private string GetPreviousChoice()
        {
            foreach (string k in Playlist)
            {
                if (k == fileToOpen)
                {
                    if (Playlist.IndexOf(k) > 0)
                    {
                        return Playlist[Playlist.IndexOf(k) - 1];
                    }
                    else
                    {
                        return Playlist[Playlist.Count-1];
                    }
                }
            }
            return Playlist[0]; //this should never be reached
        }
        private void ReadVirtualList()
        {
            string content;
            if(System.IO.File.Exists(path))
            {
                    content = System.IO.File.ReadAllText(path);
                    if(content!=string.Empty)
                    {
                        string songname = "";
                        char[] temp = content.ToCharArray();
                        for(int i=0;i<temp.Length;i++)
                        {
                            if(temp[i] == '@')
                            {
                                if(songname!=string.Empty)
                                {
                                    Playlist.Add(songname);
                                    textBox1.Text = songname + " was added to list";
                                    songname = "";
                                }
                            }
                            else
                            {
                                songname += @temp[i];
                            } 
                        }
                     }
                    else
                    {
                        textBox1.Text = "Your playlist is empty.";
                    }                                                           
                }
              else
                {
                    textBox1.Text = "Your playlist does not exist.";
                }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:/playlist.txt"); //used to open the .txt file while pressing
            //a button in windows forms.
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Playlist.Count == 0)
            {
                ReadVirtualList();
            }
            else
            {
                fileToOpen = GetPreviousChoice();
                wmplayer.URL = fileToOpen;
                wmplayer.controls.play();
                textBox1.Text = textBox1.Text = "Playing " + fileToOpen;

            }
        }

        private void Shuffle_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(Playlist.Count > 2)
            {
                Random i = new Random();
                int choice = i.Next(0, Playlist.Count);
                while(Playlist[choice] == fileToOpen)
                {
                    choice = i.Next(0, Playlist.Count);
                }
                fileToOpen = Playlist[choice];
                wmplayer.URL = fileToOpen;
                wmplayer.controls.play();
                textBox1.Text = "Playing " + fileToOpen;
            }
            else if(Playlist.Count < 2 && Playlist.Count!=0)
            {
                textBox1.Text = "Shuffling requires at least 3 elements in the playlist.";
            }
            else
            {
                textBox1.Text = "You cannot shuffle an empty playlist.";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Repeat Mode is OFF")
            {
                button9.Text = "Repeat Mode is ON";
                wmplayer.settings.setMode("Loop", true); //repeat the song
            }
            else
            {
                button9.Text = "Repeat Mode is OFF";
                wmplayer.settings.setMode("Loop", false); //repeat the song
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wmplayer.settings.volume+=10;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            wmplayer.settings.volume-=10;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if(wmplayer.settings.mute == true)
            {
                wmplayer.settings.mute = false;
                button12.Text = "Mute";
            }
            else
            {
                wmplayer.settings.mute = true;
                button12.Text = "Unmute";
            }
        }

    }
}