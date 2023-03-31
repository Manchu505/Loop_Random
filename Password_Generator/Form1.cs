using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        // Setting variables and the Random class to be used throughout form.
        int currentpasswordLength = 0;
        int howmanyPW;
        Random character = new Random();


        private void Form1_Load(object sender, EventArgs e)
        {
            //changing up elemets on the form for astetics 
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        
        private void passwordGenerator(int passwordLength)
        {
            // this is the for loop to actaully create the passwords
            // I created mulitple types of string input incase I want to change how passwords are created later
            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            string AllChar = CapitalLetters + SmallLetters + Digits + SpecialCharacters;

            string randomPassword = "";

            for (int i = 0; i < passwordLength; i++)
            {
                int randomNum = character.Next(0, AllChar.Length);
                randomPassword += AllChar[randomNum];
            }
            
            // Prints the passwords to a rich text box
            richTextBox1.AppendText(randomPassword + "\n");
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // this is the loop for generating more than one password at a time
            // good example of do-while loop
            int c = 1;
            int howmanyPW = int.Parse(textBox2.Text);

            try
            {
                do 
                {
                    int passwordLengthinput = int.Parse(textBox1.Text);
                    
                    currentpasswordLength = passwordLengthinput;
                    passwordGenerator(currentpasswordLength);
                    c++;
                }
                while (c <= howmanyPW);
            }
            catch (Exception)
            {
                MessageBox.Show("try again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Save to text file - currently saving to /bin/debug
            StreamWriter sf = new StreamWriter("password.txt", true);
            sf.WriteLine(richTextBox1.Text);
            sf.Flush();
            sf.Close(); 

            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close the application
            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Clear all boxes
            richTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}

