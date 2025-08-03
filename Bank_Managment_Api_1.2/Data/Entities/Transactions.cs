using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Managment_Api_1._2.Entities;

public class Transactions
{
    [Key]
    public Guid Id { get; set; }

    public DateTime Timestamp { get; set; }

    public required int StatusId { get; set; }

    [ForeignKey("StatusId")]
    public TransactionStatus Status { get; set; }

    public required int BankAccountId { get; set; }

    [ForeignKey("BankAccountId")]

    public BankAccount bankAccount { get; set; }

    public required string Beneficiary { get; set; }

    public decimal TransactionAmount { get; set; }

    public required int TransactionTypeId { get; set; }

    [ForeignKey("TransactionTypeId")]
    public  TransactionType TransactionType { get; set; }

}
