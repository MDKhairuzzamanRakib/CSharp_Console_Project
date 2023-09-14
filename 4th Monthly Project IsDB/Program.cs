using _4th_Monthly_Project_IsDB.AdminPart;
using _4th_Monthly_Project_IsDB.OwnerPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4th_Monthly_Project_IsDB
{
    internal class Program
    {
        private static AdminInfo adminInfo;

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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.WriteLine("\t\t\t\t\tWelcome to Food Shop Management System");
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please Select Your Option:\n1. Owner Part\n2. Admin Part\n3. Customer Part\nOption : ");
                UserType userType = (UserType)int.Parse(Console.ReadLine());

                if (userType == (UserType)1 || userType == (UserType)2 || userType == (UserType)3)
                {
                    if (userType == (UserType)1)
                    {
                        OwnerPart();
                    }
                    else if (userType == (UserType)2)
                    {
                        AdminPart();
                    }
                    else if (userType == (UserType)3)
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
            Console.Write("\nEnter Your Access Key : ");
            string AccessKey = Console.ReadLine();

            if (AccessKey.ToLower() == "khairuzzaman")
            {
                AccessDone();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Access Key");
                Console.ForegroundColor = ConsoleColor.White;
                OwnerPart();
            }

            void AccessDone()
            {
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.WriteLine("1. View Admin");
                Console.WriteLine("2. Add Admin");
                Console.WriteLine("3. Edit Admin");
                Console.WriteLine("4. Delete Admin");
                Console.WriteLine("0. Back");
                Console.Write("Option : ");

                var index = int.Parse(Console.ReadLine());
                Show(index);
            }

            void Show(int index)
            {
                AdminRepo adminRepo = new AdminRepo();

                //Show Admin Details
                if (index == 1)
                {
                    DisplayTotalAdmin();
                    AccessDone();
                }

                //Add Admin
                else if (index == 2)
                {
                    Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                    Console.Write("Admin Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Admin Password : ");
                    string password = Console.ReadLine();

                    int maxId = adminRepo.ShowAdmin().Any() ? adminRepo.ShowAdmin().Max(x => x.AdminId) : 0;

                    AdminInfo adminInfo = new AdminInfo
                    {
                        AdminId = maxId + 1,
                        AdminName = name,
                        AdminPass = password
                    };

                    adminRepo.AddAdmin(adminInfo);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t\t\t\t\t=========================");
                    Console.WriteLine("\t\t\t\t\tAdmin Created Succesfull");
                    Console.WriteLine("\t\t\t\t\t=========================");
                    Console.ForegroundColor = ConsoleColor.White;
                    AccessDone();
                }

                //Update Admin
                else if (index == 3)
                {
                    DisplayTotalAdmin();
                    Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                    Console.Write("Enter Admin ID to Update : ");
                    int id = int.Parse(Console.ReadLine());
                    var _adminInfo = adminRepo.GetAdmin(id);

                    if (_adminInfo == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("==========================");
                        Console.WriteLine("Admin id is invalid!!!");
                        Console.WriteLine("==========================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("Updated Name : ");
                        string name = Console.ReadLine();
                        Console.Write("Updated Password : ");
                        string password = Console.ReadLine();

                        AdminInfo adminInfo = new AdminInfo
                        {
                            AdminId = id,
                            AdminName = name,
                            AdminPass = password
                        };
                        adminRepo.UpdateAdmin(adminInfo);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nData updated successfully!!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayTotalAdmin();
                        AccessDone();
                    }
                }


                else if (index == 4)
                {
                    DisplayTotalAdmin();
                    Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                    Console.Write("Enter Admin ID to Delete : ");
                    int id = int.Parse(Console.ReadLine());
                    var _adminInfo = adminRepo.GetAdmin(id);

                    if (_adminInfo == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("==========================");
                        Console.WriteLine("Admin id is invalid!!!");
                        Console.WriteLine("==========================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        adminRepo.DeleteAdmin(id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nData Deleted Successfully!!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Display();
                    }
                }

                //Go to Back
                else if (index == 0)
                {
                    Display();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease select correct Option");
                    Console.ForegroundColor = ConsoleColor.White;
                    Display();
                }


                //Display Total Admins
                void DisplayTotalAdmin()
                {
                    var adminList = adminRepo.ShowAdmin();
                    if (adminList.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\t\tNo Admin found in the list!!!");
                        Console.WriteLine("\t\t\t\t\t=============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        AccessDone();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\t\t\t\t\t============================");
                        Console.WriteLine("\t\t\t\t\t\tTotal Admin");
                        Console.WriteLine("\t\t\t\t\t============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in adminRepo.ShowAdmin())
                        {
                            Console.WriteLine($"\nAdmin ID : {item.AdminId}\nAdmin Name : {item.AdminName}\nAdmin Password : {item.AdminPass}\n");
                        }
                    }
                }


            }

        }

        //Admin Part Start From Here
        public static void AdminPart()
        {
            AdminRepo adminRepo = new AdminRepo();
            var adminList = adminRepo.ShowAdmin();
            if (adminList.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t============================");
                Console.WriteLine("\t\t\t\t\tNo Admin found in the list!!!");
                Console.WriteLine("\t\t\t\t\t============================");
                Console.ForegroundColor = ConsoleColor.White;
                Display();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t\t\t***************************************\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Admin Id : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Admin Password : ");
                string password = Console.ReadLine();

                foreach (var item in adminRepo.ShowAdmin())
                {
                    if (item.AdminId != id || item.AdminPass != password)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t\t\t\t===================================");
                        Console.WriteLine("\t\t\t\t\tAdmin Id or Admin Password is Wrong");
                        Console.WriteLine("\t\t\t\t\t===================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        AdminPart();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\t\t\t\t\t=============================");
                        Console.WriteLine($"\t\t\t\t\tWelcome {item.AdminName}");
                        Console.WriteLine("\t\t\t\t\t=============================");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n1. View all Menu\n2. Insert an Item\n3. Update an Item\n4. Delete an Item\n0. Back\nOption : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int index = int.Parse(Console.ReadLine());
                    }
                }
            }

        }

        //Customer Part Start From Here
        public static void CustomerPart()
        {
            Console.WriteLine("Customer Part");
        }
    }
}
