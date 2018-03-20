using System;
using System.Collections.Generic;
using System.Text;

namespace Bban
{
    class Bank
    {
        //Fields
        public string Name;
        public double AccountNumber;

        //Constructor
        public Bank()
        {
            Name = "unknown";
            AccountNumber = 0;
        }

        public Bank(string name, double accountnumber)
        {
            Name = name;
            this.AccountNumber = accountnumber;
        }

        //Methods
    }
}
