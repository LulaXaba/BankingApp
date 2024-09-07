using System;
using System.Collections.Generic;

namespace BankingAppC3.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? SenderAccountId { get; set; }

    public int? ReceiverAccountId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Account? ReceiverAccount { get; set; }

    public virtual Account? SenderAccount { get; set; }
}
