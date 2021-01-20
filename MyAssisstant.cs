using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Siri
{
    public partial class MyAssisstant : Form
    {
        bool search = false;
        SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechRecognitionEngine reco = new SpeechRecognitionEngine();

        public MyAssisstant()
        {
            InitializeComponent();

            
            Choices list = new Choices();

            list.Add(new string[] { "hi", "open google", "open my picture", "open you tube", "open notepad", "who is your father", "bye", "full screen", "minimize", "exit program", "search for","dog",
            "open text reader","open b","what is today","what is the time"});
            Grammar gm = new Grammar(new GrammarBuilder(list));

            try
            {
                reco.RequestRecognizerUpdate();
                reco.LoadGrammar(gm);
                reco.SpeechRecognized += Reco_SpeechRecognized;
                reco.SetInputToDefaultAudioDevice();
                reco.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { }

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                reco.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                reco.RecognizeAsyncStop();
            }

        }*/

        private void Reco_SpeechRecognized(object sender, SpeechRecognizedEventArgs e )
        {
            string a = e.Result.Text;

            if(a=="search for")
            {
                search = true;
                s.Speak("tell me what to search");   
                
            }

            if(search)
            {
                string wx = e.Result.Text;
                Process.Start("https://www.google.co.in/search?q=" + wx);
                search = false;
            }

            if(a == "open text reader")
            {
                Form intro = new Intro();
                intro.Show();
                s.SpeakAsync("opening textreader");

            }

            if (search == false)
            {

                switch (a)
                {
                    case ("hi"):
                        s.Speak("hello sir");
                        break;

                    case ("who is your owner"):
                        s.Speak("Saad Iqbal is my owner");
                        break;

                    case ("open google"):
                        s.Speak("opening google");
                        Process.Start("https://wwww.google.com");
                        break;

                    case ("open you tube"):
                        s.Speak("opening youtube");
                        Process.Start("https://www.youtube.com");
                        break;

                    case ("open my picture"):
                        s.Speak("opening your picture sir");
                        Process.Start("C:\\Users\\DLS\\Downloads\\h1.PNG");
                        break;

                    case ("open notepad"):
                        s.Speak("opening notepad");
                        Process.Start("notepad.exe");
                        break;

                    case ("bye"):
                        s.Speak("bye sir have nice day");
                        this.Close();
                        break;

                    case ("full screen"):
                        s.Speak("miximizing screen");
                        WindowState = FormWindowState.Maximized;
                        break;

                    case ("minimize"):
                        s.Speak("minimize screen");
                        WindowState = FormWindowState.Minimized;
                        break;

                    case ("exit program"):
                        SendKeys.Send("%{f4}");
                        break;

                    case ("open b"):
                        Form websearch = new websearch();
                        WindowState = FormWindowState.Minimized;
                        websearch.Show();
                        break;

                    case ("what is today"):
                        s.Speak("today is " + DateTime.Now.ToShortDateString());
                        break;

                    case ("what is the time"):
                        s.Speak("it is " + DateTime.Now.ToShortTimeString());
                        break;




                }
            }
        }

       

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            
        }

        private void gunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Intro obj = new Intro();
            this.Hide();
            obj.ShowDialog();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            websearch obj = new websearch();
            this.Hide();
            obj.ShowDialog();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.ShowDialog();
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {

            BookRead obj1 = new BookRead();
            this.Hide();
            obj1.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
