using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace FinalPojectPRG282
{
    public partial class LoginForm : Form
    {
        string path = "MyTest.txt";
        List<string> users = new List<string>();
        public LoginForm()
        {
            InitializeComponent();
            
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                users = File.ReadLines(path).ToList();
            }
        }
  
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Encriptor en = new Encriptor();
            string username = txtusern.Text;
            string password = txtpassw.Text;
            
            if (users.Contains(username))
            {
                MessageBox.Show("Username already exists.", "Error");
            }
            else
            {
                users.Add(username);
                users.Add(en.Encript(password));
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach ( var user in users)
                    {
                        sw.WriteLine(user);
                    }
                }
                MessageBox.Show("User: " + username + " added", "Success");
                
            }
            

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Encriptor en = new Encriptor();
            string username = txtusern.Text;
            string password = txtpassw.Text;
            if (users.Contains(username))
            {
                int userIndex = users.IndexOf(username);
                if (password == en.Decript(users[userIndex + 1]))
                {
                    UserForm f2 = new UserForm();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Password is incorrect", "Error");
                }
            }
            else
            {
                MessageBox.Show("Username does not exist", "Error");
            }
        }

       
    }
}
