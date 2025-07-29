using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Managment_Api_1._2.Entities;

public class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    public DateTime Timestamp { get; set; }

    public int StatusId { get; set; }

    [ForeignKey("StatusId")]
    public required TransactionStatus Status { get; set; }

    public int BankAccoutnId { get; set; }

    public required BankAccount bankAccount { get; set; }

    public required string Beneficiary { get; set; }

    public decimal TransactionAmount { get; set; }

    public int TransactionTypeId { get; set; }
    
    public required TransactionType TransactionType { get; set; }


}
