using BankProject.BusinessLogicLayer;
using BankProject.Entities;
using BankProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Presentation
{
   public class CustomerManager
    {
        private static CustomerBLL customerBLL;
        public CustomerManager()
        {
            customerBLL = new CustomerBLL();
        }

        public bool Login()
        {
            Console.WriteLine("::Login Page::");
            Console.Write("User Name: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            var account = customerBLL.GetCustomer(x =>
            x.Username.Equals(username) && x.Password.Equals(password));
            if (account is null)
            {
                Console.WriteLine("UserName or password is incorrect");
                Console.WriteLine();
                return false;
            }
            return true;
        }

        public void Delete()
        {
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            customerBLL.DeleteByCustomerByPhone(phone);
        }

        public void DisplayListCustomer()
        {
            var listCustomer = customerBLL.GetAllCustomers();
            Console.WriteLine(string.Format("{0,-15} | {1,10} | {2,10} | {3,10} | {4,10} | {5,11}| {6,10} | {7,10}"
                    , "Customer Name", "Address", "Landmark", "City", "Country", "Phone", "UserName", "Password"));
            Console.WriteLine();
            foreach (var item in listCustomer)
            {
                Console.WriteLine(item.Display());
            }
            Console.WriteLine();
        }

     

        public void AddCustomer()
        {
            try
            {
                var customer = new Customer();
                Console.Write("Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("LandMark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();
                Console.Write("Username: ");
                customer.Username = Console.ReadLine();
                Console.Write("Password: ");
                customer.Password = Console.ReadLine();
                Console.Write("Customer Code: ");
                customer.CustomerCode = Convert.ToInt64(Console.ReadLine());

               bool isSuccess= customerBLL.Create(customer);
                if (isSuccess)
                {
                    Console.WriteLine($"Customer {customer.Username} was added successfully!");
                }
                else
                {
                    Console.WriteLine("Add failed!");
                }
            }
            catch(CustomerException cex)
            {
                Console.WriteLine(cex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuFind()
        {
            Console.WriteLine("::Find Customer Menu::");
            Console.WriteLine("1. Find by Username");
            Console.WriteLine("2. Find by Address");
            Console.WriteLine("3. Find by City");
            Console.WriteLine("4. Find by Phone");
            Console.WriteLine("0. Exit");
        }

        public static List<Customer> listCustomnerFound(Func<Customer, bool> predicate)
        {
            var result = customerBLL.Find(predicate);
            Console.WriteLine();
            if (result.Count != 0)
            {
                result.ForEach(x => Console.Write(x.Display()));
            }
            else
            {
                Console.WriteLine("Not found!");
            }
            Console.WriteLine();
            return result;
        }

        public void FindCustomer()
        {
            MenuFind();
            int choice = Validation.InputInt("Enter option: ");
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter UserName: ");
                        var username = Console.ReadLine();
                        listCustomnerFound(x => x.Username.Equals(username));
                        Console.WriteLine("Do you want to continue (Y/N): ");
                        if (!Validation.checkInputYN())
                        {
                            return;
                        }
                        break;
                    case 2:
                        Console.Write("Enter Address: ");
                        var address = Console.ReadLine();
                        listCustomnerFound(x => x.Address.Equals(address));
                        Console.WriteLine("Do you want to continue (Y/N): ");
                        if (!Validation.checkInputYN())
                        {
                            return;
                        }
                        break;
                    case 3:
                        Console.Write("Enter City: ");
                        var city = Console.ReadLine();
                        listCustomnerFound(x => x.City.Equals(city));
                        Console.WriteLine("Do you want to continue (Y/N): ");
                        if (!Validation.checkInputYN())
                        {
                            return;
                        }
                        break;
                    case 4:
                        Console.Write("Enter Mobile: ");
                        var phone = Console.ReadLine();
                        listCustomnerFound(x => x.Mobile.Equals(phone));
                        Console.WriteLine("Do you want to continue (Y/N): ");
                        if (!Validation.checkInputYN())
                        {
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        public void UpdateCustomer()
        {
            Console.WriteLine("::Update Customer::");
            Console.Write("Enter UserName you want to update: ");
            var updateName = Console.ReadLine();
            var customer = customerBLL.GetCustomer(x => x.Username.Equals(updateName));
            try
            {
                Console.WriteLine("-> Enter the information you want to update");
                Console.Write("Enter address");
                customer.Address = Console.ReadLine();
                Console.Write("Enter city");
                customer.City = Console.ReadLine();
                Console.Write("Enter landmark");
                customer.Landmark = Console.ReadLine();
                Console.Write("Enter country");
                customer.Country = Console.ReadLine();
                Console.Write("Enter mobile");
                string temp = Console.ReadLine();
                if (!string.IsNullOrEmpty(temp))
                {
                    customer.Mobile = temp;
                }
                Console.Write("Enter password");
                customer.Password = Console.ReadLine();
                bool isSuccess = customerBLL.Update(customer);
                if (isSuccess)
                {
                    Console.WriteLine("Update sucessfully!");
                    customer.Display();
                } else
                {
                    Console.WriteLine("Update fail!");
                }

            }
            catch (CustomerException cex)
            {
                Console.WriteLine(cex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
        }
    }
}
