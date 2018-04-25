using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp2.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Repositories
{
    class BankRepository
    {
        private readonly BankdbContext _context = new BankdbContext();
        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }
        public List<Bank> Get()
        {
            List<Bank> persons = _context.Bank.ToListAsync().Result;
            return persons;
        }

        public Bank GetBankById(int id)
        {
            var banks = _context.Bank.FirstOrDefault(b => b.Id == id);
            return banks;
        }
        public void Update(int id, Bank bank)
        {
            var UpdateBank = GetBankById(id);
            if (UpdateBank != null)
            {
                UpdateBank.Name = bank.Name;
                UpdateBank.Bic = bank.Bic;
                _context.Bank.Update(UpdateBank);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null)
            {
                _context.Bank.Remove(delBank);
                _context.SaveChanges();
            }
        }
    }

    public List<Bank> GetTransactionsFromBankCustomerAccounts()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .Include(b => b.Account)
                        .Include(b => b.Account).ThenInclude(a => a.Transaction)
                        .ToListAsync().Result;
                    return banks;
                }
                catch { Exception ex}
            }
        }
    }
}
