﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Logger:ILogger
    {
        public void WriteInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}
