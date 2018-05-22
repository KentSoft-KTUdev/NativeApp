using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryApp.Objects
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public long PersonalCode { get; set; }
        public string status { get; set; }

        //public User(string Username, string Password)
        //{
        //    username = Username;
        //    password = Password;
        //}
    }
}
