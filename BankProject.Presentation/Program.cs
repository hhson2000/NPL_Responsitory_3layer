using BankProject.BusinessLogicLayer;
using BankProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankProject.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CustomerManager();
            while (true)
            {
                if (manager.Login())
                {
                    int option = -1;
                    do
                    {
                        Console.WriteLine("=== Menu Options===");
                        Console.WriteLine("1. Add customer:");
                        Console.WriteLine("2. Get all existing customer:");
                        Console.WriteLine("3. Update customer.");
                        Console.WriteLine("4. Find");
                        Console.WriteLine("5. Delete");
                        Console.WriteLine("0. Exit");
                        Console.Write("Enter number of options:");
                        option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                manager.AddCustomer();
                                break;
                            case 2:
                                manager.DisplayListCustomer();
                                break;
                            case 3:
                                manager.UpdateCustomer();
                                break;
                            case 4:
                                manager.FindCustomer();
                                break;
                            case 5:
                                manager.Delete();
                                break;
                            default:
                                Console.WriteLine("option must between 1 and 5");
                                break;
                        }
                    } while (option != 0);
                }
            }
        }
    }
}
