using BankProject.DataAccessLayer;
using BankProject.Entities;
using BankProject.Exceptions;
using System;
using System.Collections.Generic;

namespace BankProject.BusinessLogicLayer
{
    public class CustomerBLL : ICustomerBLL
    {
        private static ICustomerService _customerService;

        public CustomerBLL()
        {
            _customerService = new CustomerService();
        }

        public bool Create(Customer customer)
        {
            try
            {
                customer.Id = Guid.NewGuid();
                return _customerService.Create(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                // tu viet.
                throw;
            }
        }

        public bool DeleteByCustomerByPhone(string phone)
        {
            try
            {
                return _customerService.DeleteByCustomerPhone(phone);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Customer> Find(Func<Customer, bool> predicate)
        {
            return _customerService.Find(predicate);
        }

        public Customer FindBy(Func<Customer, bool> predicate)
        {
            var result = _customerService.GetCustomer(predicate);
            Console.WriteLine();
            if (result != null)
            {
                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine("Not found!");
            }
            Console.WriteLine();
            return result;
        }

        public bool Update(Customer customer)
        {
            try
            {
                return _customerService.Update(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }


        public Customer GetCustomer(Func<Customer, bool> predicate)
        {
            return _customerService.GetCustomer(predicate);
        }
    }
}