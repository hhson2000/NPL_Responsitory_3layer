using BankProject.Exceptions;
using System;

namespace BankProject.Entities
{
    public class Customer : ICloneable
    {
        private long _customerCode;
        private string _customerName;
        private string _mobile;

        public Guid Id { get; set; }

        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (value > 0)
                    _customerCode = value;
                else
                    throw new CustomerException("CustomerCode must greater than 0");
            }
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (value.NotNullAndLessThan40Characters())
                    _customerName = value;
                else
                    throw new CustomerException("CustomerName must not null and less than 40 characters.");
            }
        }

        public string Address { get; set; }

        public string Landmark { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Mobile
        {
            get => _mobile;
            set
            {
                if (value.Length == 10)
                    _mobile = value;
                else
                    throw new CustomerException("Mobile must has 10 10-digit number");
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public object Clone()
        {
            var customer = new Customer();
            customer.Id = Id;
            customer.Landmark = Landmark;
            customer.Mobile = Mobile;
            customer.Password = Password;
            customer.Username = Username;
            customer.CustomerCode = CustomerCode;
            customer.CustomerName = CustomerName;
            customer.Address = Address;
            return customer;
        }

        /* public Customer Clone()
         {
             var customer = new Customer();
             customer.Id = Id;
             customer.Landmark = Landmark;
             customer.Mobile = Mobile;
             customer.Password = Password;
             customer.Username = Username;
             customer.CustomerCode = CustomerCode;
             customer.CustomerName = CustomerName;
             customer.Address = Address;
             return customer;
         }*/

        public string Display()
        {
            return string.Format("{0,-15} | {1,10} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10}",
                CustomerName, Address, Landmark, City, Country, Mobile, Username, Password);
        }
    }
}