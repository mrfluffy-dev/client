using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LocalLoginSystem
{
   
    public partial class Form1 : Form
    {










        

        
        List<User> userr = new List<User>();

        private readonly string[] mUsernames = { "username1", "username2", "username3" };//read only


        private readonly string[] mPasswords = { "password1", "password2", "password3" };//read only 

        private readonly List<string> mUserList = new List<string>();//list for 


        private readonly List<string> mPasswordList = new List<string>();

       

        public Form1()
        {
            InitializeComponent();
        }

        





        // Addd in die data handler dis alles in form filew
        
        private void Form1_Load(object sender, EventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StreamReader reder = new StreamReader("lifesucks.txt");


            string line;


            while ((line = reder.ReadLine()) != null)
            {

                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                mUserList.Add(components[0]);


                mPasswordList.Add(components[1]);
            }


            reder.Close();

            if (mUsernames.Contains(textBox1.Text) && mPasswords.Contains(textBox2.Text) && mPasswords[Array.IndexOf(mUsernames, textBox1.Text)] == textBox2.Text)
            {
                
                Form2 f2 = new Form2();

                f2.ShowDialog();
            }
           
            else if (mUserList.Contains(textBox1.Text) && mPasswordList.Contains(textBox2.Text) && mPasswordList[mUserList.IndexOf(textBox1.Text)] == textBox2.Text)
            {
               
                Form2 f2 = new Form2();

               
                f2.ShowDialog();
            }
            else
               
                MessageBox.Show("wrong user nameee");
        }

        private void regster_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text; 



            User emp = new User(username, password);
            userr.Add(emp);

            richTextBox1.AppendText(emp.ToString());

            File.WriteAllText("lifesucks.txt", richTextBox1.Text);







        }
    }
}
