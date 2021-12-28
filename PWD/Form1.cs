using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PWD
{
    public partial class Form1 : Form
    {
        // Generate a random number  
        Random random = new Random();
        // Any random integer   
        //int num = random.Next();
        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        // Generate a random password of a given length (optional)  




        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }




        public Form1()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Location = button1.Location;
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5, true));
            builder.Append(random.Next(1000, 9999));
            builder.Append(RandomString(5, false));
            richTextBox1.Text = builder.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Location = button2.Location;
            string encrypted=EncryptString(richTextBox1.Text);
            richTextBox1.Text = encrypted;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       



        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Location = button3.Location;
            string decrypted =  DecryptString(richTextBox1.Text);
            richTextBox1.Text = decrypted;
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
        }
    }
}
