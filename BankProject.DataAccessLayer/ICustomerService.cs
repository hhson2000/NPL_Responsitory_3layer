using BankProject.Entities;
using System;
using System.Collections.Generic;

namespace BankProject.DataAccessLayer
{
    public interface ICustomerService
    {
        bool Create(Customer customer);

        bool DeleteByCustomerPhone(string phone);

        bool Update(Customer customer);

        List<Customer> Find(Func<Customer, bool> predicate);

        Customer GetCustomer(Func<Customer, bool> predicate);

        List<Customer> GetAllCustomers();
    }
}