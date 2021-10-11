using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalLoginSystem
{
    class User
    {

        string username;
        string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }


      /*  public readonly string[] mUsernames = { "username1", "username2", "username3" };


        public readonly string[] mPasswords = { "password1", "password2", "password3" };

        public readonly List<string> mUserList = new List<string>();


        public readonly List<string> mPasswordList = new List<string>();*/ // in MAIN file private 



        public override string ToString()
        {
            return string.Format($" {this.username} {this.password} \n");
        }






    }
}
