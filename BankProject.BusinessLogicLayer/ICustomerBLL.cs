using BankProject.Entities;
using System;
using System.Collections.Generic;

namespace BankProject.BusinessLogicLayer
{
    public interface ICustomerBLL
    {
        bool Create(Customer customer);

        bool DeleteByCustomerByPhone(string phone);

        bool Update(Customer customer);

        List<Customer> GetAllCustomers();
        List<Customer> Find(Func<Customer, bool> predicate);

        Customer GetCustomer(Func<Customer, bool> predicate);

   
    }
}