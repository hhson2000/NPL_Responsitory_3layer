using BankProject.Entities;
using BankProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankProject.DataAccessLayer
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    Id= Guid.NewGuid(),
                    CustomerName="Nguyen Van A",
                    Address = "HaNoi",
                    Landmark = "Vincom",
                    City = "Tong Duy Tan",
                    Country = "VN",
                    Username="A",
                    Password="A123456a",
                    Mobile="1234567890",
                    CustomerCode=10
                }
            };
        }

        public bool Create(Customer customer)
        {
            try
            {
                if (_customers.IsUniquePhone(customer.Mobile)
                    && _customers.IsUniqueUsername(customer.Username))
                {
                    _customers.Add(customer);
                    return true;
                }
                return false;
            }
            catch (CustomerException cex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteByCustomerPhone(string phone)
        {
            try
            {
                var customerExisting = Find(x => x.Mobile == phone).FirstOrDefault();
                if (customerExisting != null)
                {
                    _customers.Remove(customerExisting);
                    return true;
                }
                return false;
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
            return _customers.Where(predicate).ToList();
        }

        public List<Customer> GetAllCustomers() => _customers;

        public Customer GetCustomer(Func<Customer, bool> predicate)
        {
            return _customers.SingleOrDefault(predicate).Clone() as Customer;
        }

        public bool Update(Customer customer)
        {
            try
            {
                var customerExisting = _customers.FirstOrDefault(x => x.Id == customer.Id);

                if (customerExisting != null)
                {
                    if (!string.IsNullOrEmpty(customer.Username))
                    {
                        customerExisting.Username = customer.Username;
                    }
                    if (!string.IsNullOrEmpty(customer.City))
                    {
                        customerExisting.City = customer.City;
                    }
                    if (!string.IsNullOrEmpty(customer.Country))
                    {
                        customerExisting.Country = customer.Country;
                    }
                    if (!string.IsNullOrEmpty(customer.Mobile))
                    {
                        customerExisting.Mobile = customer.Mobile;
                    }
                    if (!string.IsNullOrEmpty(customer.Password))
                    {
                        customerExisting.Password = customer.Password;
                    }
                    return true;
                }
                return false;
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
    }
}