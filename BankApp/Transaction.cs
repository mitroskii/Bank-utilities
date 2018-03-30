using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Transaction
    {

        public double Sum; 
        private DateTime _timeStamp;

        
        public Transaction(double sum, DateTime timestamp)
        {
            Sum = sum;
            _timeStamp = timestamp;
        }

        public double sum { get => Sum; set => Sum = value; }
        public DateTime TimeStamp { get => _timeStamp; set => _timeStamp = value; }
    }
}
