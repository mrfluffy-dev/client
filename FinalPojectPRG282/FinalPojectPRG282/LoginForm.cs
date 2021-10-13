using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace FinalPojectPRG282
{
    public partial class LoginForm : Form
    {
        FileHandler fh = new FileHandler();
        public LoginForm()
        {
            InitializeComponent();
            
            if(!File.Exists(fh.path))
            {
                File.Create(fh.path);
            }
            else
            {
                fh.users = File.ReadLines(fh.path).ToList();
            }
        }
  
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Encriptor en = new Encriptor();
            string username = txtusern.Text;
            string password = txtpassw.Text;
            
            if (fh.users.Contains(username))
            {
                MessageBox.Show("Username already exists.", "Error");
            }
            else
            {
                fh.users.Add(username);
                fh.users.Add(en.Encript(password));
                using (StreamWriter sw = new StreamWriter(fh.path))
                {
                    foreach ( var user in fh.users)
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
            if (fh.users.Contains(username))
            {
                int userIndex = fh.users.IndexOf(username);
                if (password == en.Decript(fh.users[userIndex + 1]))
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
