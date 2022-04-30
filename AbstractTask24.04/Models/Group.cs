using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractTask24._04.Models
{
    class Group
    {
        private int _studentLimit;
        public string GroupNo { get; set; }
        public int StudentLimit
        {
            get
            {
                return _studentLimit;
            }
            set
            {
                if (value > 5 || value < 18)
                {
                    _studentLimit = value;
                }
            }
        }

        private Student[] _students = new Student[0];
        public Group(string groupNo, int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public bool CheckGroupNo(string groupNo)
        {

            if (groupNo.Length == 5 && !string.IsNullOrEmpty(groupNo) && !string.IsNullOrWhiteSpace(groupNo))
            {
                int digitCount = 0;
                int upperCount = 0;


                for (int i = 0; i < groupNo.Length - 2; i++)
                {
                    if (i < 2)
                    {
                        if (char.IsUpper(groupNo[i])) digitCount++;

                    }
                    else if (digitCount == 2 && i >= 2)
                    {
                        if (char.IsDigit(groupNo[i])) digitCount++;
                    }
                    else
                    {
                        return false;
                    }
                    if (upperCount == 2 && digitCount == 3)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public void AddStudent(Student student)
        {
            if (StudentLimit>5 || StudentLimit<18)
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Groupda yer yoxdur!");
            }
            
        }
        public Student  GetStudent(int? id)
        {
            Student wantedstudent = null;
            if (id == null)
            {
                throw new Exception("error");
            }
            else
            {
                foreach (var item in _students)
                {
                    if (item.Id == id)
                    {
                        wantedstudent = item;
                        break;
                    }
                }
            }
            return wantedstudent ;
        }
        public void GetAllStudent()
        {
            foreach (Student item in _students)
            {
                item.ShowInfo();
            }
        }
        

    }
}
