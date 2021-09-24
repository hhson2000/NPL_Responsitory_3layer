﻿using System;

namespace BankProject.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException()
        {
        }

        public CustomerException(string message) : base(message)
        {
        }

        public CustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}