using AbstractTask24._04.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractTask24._04.Models
{
    class User : IAccount
    {
        private static int _id;
        private string _password;
        public int Id { get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password{
            get
            {
                return _password;
            }
            set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
                else
                {
                    throw new Exception("Password Sehvdir");
                }
            }
        }
        private User()
        {
            _id++;
            Id = _id;
        }
        public User(string email,string password):this()
        {
            Email = email;
            Password = password;
        }
        public bool PasswordChecker(string password)
        {
            if (password.Length>8 && !string.IsNullOrEmpty(password))
            {
                bool isDigit = false;
                bool isUpper = false;
                bool isLower = false;

                for (int i = 0; i < password.Length; i++)
                {

                    if (char.IsDigit(password[i]))
                    {
                        isDigit = true;
                    }
                    else if (char.IsUpper(password[i]))
                    {
                        isUpper = true;
                    }
                    else if (char.IsLower(password[i]))
                    {
                        isLower = true;
                    }
                    if (isDigit &&isLower && isUpper)
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($@"Id -->{Id}
Full Name -->{FullName}
Email -->{Email}");
        }
    }
}
