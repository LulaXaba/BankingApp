using BankingAppC3;
using BankingAppC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppC3.Services.IService
{
    public interface IAccountService
    {
        Account GetAccountById(int accountId);
        IEnumerable<Account> GetAllAccounts();
        void CreateAccount(Account account);

        void UpdateAccountBalance(int accountId, decimal newBalance);
        void TransferFunds(int senderAccountId, int receiverAccountId, decimal amount);
    }
}
