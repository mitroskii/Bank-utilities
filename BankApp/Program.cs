using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankApp");
            Bank bank = new Bank("Center Bank");
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Donald", "Duck", bank.CreateAccount()));
            customers.Add(new Customer("Scrooge", "McDuck", bank.CreateAccount()));
            customers.Add(new Customer("Gyro", "Gearloose", bank.CreateAccount()));
            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 12, 0, 0);
            var startTime = endTime.Date - time;
            Console.WriteLine($"Transactions from last year:{startTime.ToShortDateString()}" + $"-{endTime.ToShortDateString()}");
            Random rnd = new Random();
            for (int i = 0; i < 500; i++)
            {
                bank.AddTransactionForCustomer(customers[rnd.Next(0, 3)].AccountNumber, new Transaction(rnd.Next(-50000, 50000),
                    new DateTime(rnd.Next(2016, 2019), rnd.Next(1, 13), rnd.Next(1, 29))));
            }
            for (int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank, customers[i]);
                PrintTransaction(bank.GetTransactionsForCustomerForTimeSpan(customers[i].AccountNumber, startTime, endTime), customers[i]);
            }
            Console.WriteLine("<Enter> to exit!");
            Console.ReadLine();
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}", customer.ToString(), balance >= 0 ? "+" : "", balance);
        }

        public static void PrintTransaction(List<Transaction> transactions, Customer customer)
        {
            Console.WriteLine($"Transactions {customer.FirstName} {customer.LastName}:");
            for (int i = 0; i < transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}", transactions[i].TimeStamp.ToShortDateString(), transactions[i].Sum >= 0 ? "+" : "",
                    transactions[i].Sum);
            }
            Console.WriteLine("\n");
        }
    }
}
//Oman pankkinumeron tarkistus
//FI23 5482 3720 0153 38
//     2121 2121 2121 2
//    1+0+4+1+6+2+6+7+4+0+0+1+1+0+3+6=50-42=8
//string machineFormat = BankUtil.CorrectNumber("227720-35988");
//Console.WriteLine(BankUtil.isValidAccount(machineFormat));
  //          Console.ReadKey();