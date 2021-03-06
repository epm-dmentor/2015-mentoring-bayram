﻿using System;

namespace StockExchangeInterfaces
{
    public class InSufficientBalanceException : Exception
    {
        public InSufficientBalanceException(string empty)
        {
            Console.WriteLine(empty);
        }
    
    }
    
    public class NonExistingAccountException : Exception
    {
        public NonExistingAccountException(string empty)
        {
            Console.WriteLine(empty);
        }
        
    }

    public class NonExistingShareExeption : Exception
    {
        public NonExistingShareExeption(string empty)
        {
            Console.WriteLine(empty);
        }
        
    }

    public class NotEnoughShareExeption : Exception
    {
        public NotEnoughShareExeption(string empty)
        {
            Console.WriteLine(empty);
        }
        
    }

    public class BrokerNotFoundExeption : Exception
    {
        public BrokerNotFoundExeption(string empty)
        {
            Console.WriteLine(empty);
        }

    }
}
