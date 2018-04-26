using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BankApp2.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Repositories
{
    class TransactionRepository
    {
        private readonly BankdbContext _context = new BankdbContext();
        public List<Transaction> Read()
        {
            List<Transaction> transactions = _context.Transaction.ToListAsync().Result;
            return transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            var transaction = _context.Transaction.FirstOrDefault(t => t.Id == id);
            return transaction;
        }
    }
}
