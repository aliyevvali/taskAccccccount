using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractTask24._04.Models
{
    class Student
    {
        private static int _id;
        public int Id { get; }
        public string FullName { get; set; }
        public double Point { get; set; }
        private Student()
        {
            _id++;
            Id = _id;
        }
        public Student(string fullName,double point):this()
        {
            FullName = fullName;
            Point = point;
        }

        public void ShowInfo()
        {
            Console.WriteLine($@"Id --> {Id}
Full Name --> {FullName}
Point -->{Point}");
        }

    }
}
