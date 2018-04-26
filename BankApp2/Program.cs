using System;
using BankApp2.Model;
using Microsoft.EntityFrameworkCore;
using BankApp2.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace BankApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("BankApp");
            Print();

            Console.WriteLine("\n<Enter> ends program!");
            Console.ReadLine();
        }
            static void CreateBank()
            {
                BankRepository bankRepository = new BankRepository();
                Bank b = new Bank("Lappeenrannan pankki", "LPIFF");
                Bank b2 = new Bank("Kuopion pankki", "KPIFF");
            }
            static void UpdateBank()
            {
                BankRepository bankRepository = new BankRepository();
                Bank updateBank = bankRepository.GetBankById(1);
                updateBank.Name = "Sammonlahden pankki";
                updateBank.Bic = "SLIFF";
                bankRepository.UpdateBank(1, updateBank);
            }
            static void DeleteBank()
            {
                BankRepository bankRepository = new BankRepository();
                bankRepository.DeleteBank(2);
            }
            static void CreateCustomer()
            {
                CustomerRepository customerRepository = new CustomerRepository();
                Customer c1 = new Customer("Pekka", "Koivu", 11);
                Customer c2 = new Customer("Helinä", "Keiju", 12);
                customerRepository.CreateCustomer(c1);
                customerRepository.CreateCustomer(c2);
            }
            static void UpdateCustomer()
            {
                CustomerRepository customerRepository = new CustomerRepository();
                Customer updateCustomer = customerRepository.GetCustomerById(7);
                updateCustomer.Firstname = "Vihreä";
                updateCustomer.Lastname = "Omena";
                customerRepository.UpdateCustomer(3, updateCustomer);
            }
            static void DeleteCustomer()
            {
                CustomerRepository customerRepository = new CustomerRepository();
                customerRepository.DeleteCustomer(5);
            }
            static void CreateTransaction()
            {
                AccountRepository accountRepository = new AccountRepository();

                TransactionRepository transactionRepository = new TransactionRepository();
                Transaction transaction = new Transaction
                {
                    Iban = "FI12345",
                    Amount = 2500,
                    TimeStamp = DateTime.Now
                };
                accountRepository.CreateTransaction(transaction);
            }
            static void Print()
            {
                BankRepository bankRepository = new BankRepository();

                var bankCustomers = bankRepository.GetTransactionsFromBankCustomerAccounts();

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
    
    

        
