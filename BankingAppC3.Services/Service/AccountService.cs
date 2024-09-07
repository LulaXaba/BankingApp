using BankingAppC3.Models;
using BankingAppC3.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppC3.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly BankingAppDbContext _context;

        public AccountService(BankingAppDbContext context)
        {
            _context = context;
        }

        public Account GetAccountById(int accountId)
        {
            return _context.Accounts
                           .Include(a => a.TransactionReceiverAccounts)
                           .Include(a => a.TransactionSenderAccounts)
                           .FirstOrDefault(a => a.AccountId == accountId);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts.Include(a => a.User).ToList();
        }

        public void CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void UpdateAccountBalance(int accountId, decimal newBalance)
        {
            var account = GetAccountById(accountId);
            if (account != null)
            {
                account.Balance = newBalance;
                _context.SaveChanges();
            }
        }

        public void TransferFunds(int senderAccountId, int receiverAccountId, decimal amount)
        {
            var senderAccount = GetAccountById(senderAccountId);
            var receiverAccount = GetAccountById(receiverAccountId);

            if (senderAccount != null && receiverAccount != null && senderAccount.Balance >= amount)
            {
                senderAccount.Balance -= amount;
                receiverAccount.Balance += amount;

                // Create a new transaction record
                var transaction = new Transaction
                {
                    SenderAccountId = senderAccountId,
                    ReceiverAccountId = receiverAccountId,
                    Amount = amount,
                    TransactionDate = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds or invalid accounts.");
            }
        }
    }
}
