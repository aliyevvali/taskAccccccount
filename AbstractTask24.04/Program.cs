using AbstractTask24._04.Models;
using System;

namespace AbstractTask24._04
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Email daxil edin :");
            string email = Console.ReadLine();
            Start:
            Console.WriteLine("Password daxil edin :");
            string password = Console.ReadLine();
            if (!PasswordChecker(password)) goto Start;

            User user = new User(email,password);
            Console.WriteLine("Full name:");
            user.FullName = Console.ReadLine();

            int choice;
            do
            {
                Console.WriteLine("1)User Show Info-------2)Create New Group-------0)Quit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("---------------------------------------------------------");
                        user.ShowInfo();
                        Console.WriteLine("---------------------------------------------------------");
                        break;
                    case 2:
                        string groupNo = "";
                        int limit = -1;
                        InputGroup(ref groupNo,ref limit);
                        Group group = new Group(groupNo, limit);

                        
                        int choice1;
                        do
                        {
                            Console.WriteLine("1)Get All Students-------2)Get By Id-------3)Add Student 0)Quit");
                            choice1 = int.Parse(Console.ReadLine());
                            switch (choice1)
                            {
                                
                                case 1:
                                    group.GetAllStudent();
                                    break;
                                case 2:
                                    Console.WriteLine("Id daxil edin ");
                                    int id = int.Parse(Console.ReadLine());

                                    Console.WriteLine(group.GetStudent(id).ToString()); ;
                                    break;
                                case 3:
                                    Console.WriteLine("Full name ");
                                    string fullname = Console.ReadLine();
                                    Console.WriteLine("Point daxin edin");
                                    double point = double.Parse(Console.ReadLine());

                                    Student student = new Student(fullname, point);
                                    group.AddStudent(student);
                                    break;
                                default:
                                    break;
                            }
                        } while (choice1!=0);
                        

                        break;

                    default:
                        Console.WriteLine("1,2 and 0");
                        break;
                }
            } while (choice!=0);

            
            

        }
        static bool PasswordChecker(string password)
        {
            if (password.Length > 8 && !string.IsNullOrEmpty(password))
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
                    if (isDigit && isLower && isUpper)
                    {
                        return true;
                    }

                }

            }
            return false;
        }
        static void InputGroup(ref string groupNo,ref int studentLimit)
        {
            Start:
            try
            {
                Console.WriteLine("Please enter Group No");
                groupNo = Console.ReadLine();
                groupNo.Trim();

                if (groupNo.Length == 5 && !string.IsNullOrEmpty(groupNo) && !string.IsNullOrWhiteSpace(groupNo))
                {
                    int digitCount = 0;
                    int upperCount = 0;
                    bool flag = false;

                    for (int i = 0; i < groupNo.Length; i++)
                    {
                        if (i < 2)
                        {
                            if (char.IsUpper(groupNo[i])) upperCount++;
                        }
                        else if (i >= 2 && upperCount == 2)
                        {
                            if (char.IsDigit(groupNo[i])) digitCount++;
                        }
                        if (upperCount == 2 && digitCount == 3)
                        {
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        throw new Exception();
                    }
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto Start;
            }
            Limit:  
            try
            {
                Console.WriteLine("Please enter student limit");
                studentLimit = int.Parse(Console.ReadLine());
                if (studentLimit < 5 || studentLimit > 18) throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto Limit;
            }

        }
        
    }
}
