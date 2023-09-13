using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4th_Monthly_Project_IsDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display();
            Console.ReadKey();
        }

        public static void Display()
        {
            int temp = 0;
            while (temp == 0) 
            {
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.WriteLine("\t\t\t\t\tWelcome to Food Shop Management System");
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.Write("Please Select Your Option:\n1. Owner Part\n2. Admin Part\n3. Customer Part\nOption : ");
                UserType userType = (UserType)int.Parse(Console.ReadLine());

                if (userType == (UserType) 1 || userType == (UserType) 2 || userType == (UserType) 3)
                {
                    if (userType == (UserType) 1)
                    {
                        OwnerPart();
                    }
                    else if (userType == (UserType) 2)
                    {
                        AdminPart();
                    }
                    else if (userType == (UserType) 3)
                    {
                        CustomerPart();
                    }
                    temp = 1;
                }
                else
                {
                    Console.WriteLine("Please Enter a Correct Number");
                    temp = 0;
                }
            }

        }

                //Owner Part Start From Here
        public static void OwnerPart()
        {
            Console.WriteLine("Owner Part");
        }

                //Admin Part Start From Here
        public static void AdminPart()
        {
            Console.WriteLine("Admin Part");
        }

                //Customer Part Start From Here
        public static void CustomerPart()
        {
            Console.WriteLine("Customer Part");
        }
    }
}
