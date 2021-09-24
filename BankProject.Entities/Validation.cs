using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankProject.Entities
{
    public static class Validation
    {
        public static bool IsGreaterThanZero(this string customerCode)
        {
            bool isNumber = Int64.TryParse(customerCode, out long result);
            return result > 0;
        }

        public static bool NotNullAndLessThan40Characters(this string customerName)
        {
            int length = customerName.Length;
            return length >= 1 && length < 40;
        }

        public static bool IsUniquePhone(this List<Customer> customers, string phone)
        {
            var customerExisting = customers.Find(x => x.Mobile == phone);
            return customerExisting == null;
        }

        public static bool IsUniqueUsername(this List<Customer> customers, string username)
        {
            var customerExisting = customers.Find(x => x.Username == username);
            return customerExisting == null;
        }

        public static bool IsValidPassword(this string password)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        public static int InputInt(string msg)
        {
            int number;
            do
            {
                try
                {
                    Console.Write(msg);
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number < 0)
                        continue;
                    break;
                }
                catch (Exception r)
                {
                    Console.WriteLine("wrong!");
                }
            } while (true);
            return number;
        }

        public static string InputString(string msg)
        {
            string num;
            do
            {
                Console.Write(msg);
                num = Console.ReadLine();
                if (string.IsNullOrEmpty(num))
                    return null;
                else
                    break;
            } while (true);
            return num;
        }


        public static Boolean IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        public static String checkInputString()
        {
            //loop until user input correct
            while (true)
            {
                String result = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(result) || !IsAllAlphabetic(result))
                {
                    Console.WriteLine("Empty or Wrong");
                    Console.WriteLine("Enter again: ");
                }
                else
                {
                    return result;
                }
            }
        }

        public static Boolean checkInputYN()
        {
            //loop until user input correct
            while (true)
            {
                String result = checkInputString();
                //check user input y/Y or n/N
                if (String.Equals(result, "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else if (String.Equals(result, "N", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                Console.WriteLine("Please input y/Y or n/N.");
                Console.WriteLine("Enter again: ");
            }
        }

    }
}