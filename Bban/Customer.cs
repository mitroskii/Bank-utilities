using System;
using System.Collections.Generic;
using System.Text;

namespace Bban
{
    class Customer
    {
        //Fields
        public string FirstName;
        public string LastName;
        public double AccountNumber;

        //Constructor
        public Customer()
        {
            FirstName = "unknown";
            LastName = "unknown";
            AccountNumber = 0;
        }

        public Customer(string firstname, string lastname, double accountnumber)
        {
            FirstName = firstname;
            LastName = lastname;
            this.AccountNumber = accountnumber;
        }

        //Methods

    }
}
