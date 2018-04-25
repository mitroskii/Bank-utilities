using System;
using System.Collections.Generic;
using System.Text;
using BankApp2.Model;
using BankApp2.Services;

namespace BankApp2.Views
{
    class BankView
    {
        public void PrintAllBanks()
        {
            foreach (var bC in bankCustomers)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount.ToString()}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn.ToString()}");
                        }
                    }
                }
            }
        }
    }
}
