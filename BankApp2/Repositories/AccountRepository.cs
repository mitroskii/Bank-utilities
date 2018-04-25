using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp2.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Repositories
{
    class AccountRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public List<Account> Read()
        {
            List<Account> accounts = _context.Account.ToListAsync().Result;
            return accounts;
        }

        public Account GetAccountById(string iban)
        {
            var account = _context.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public void CreateAccount(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        public void DeleteAccount(string iban)
        {
            var delAccount = _context.Account.FirstOrDefault(a => a.Iban == iban);
            if (delAccount != null)
                _context.Account.Remove(delAccount);
            _context.SaveChanges();
        }

        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                _context.Transaction.Add(transaction);
                var account = GetAccountById(transaction.Iban);
                account.Balance += transaction.Amount;
                _context.Account.Update(account);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
