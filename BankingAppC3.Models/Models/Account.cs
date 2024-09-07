using System;
using System.Collections.Generic;

namespace BankingAppC3.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public int? UserId { get; set; }

    public decimal Balance { get; set; }

    public virtual ICollection<Transaction> TransactionReceiverAccounts { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionSenderAccounts { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
