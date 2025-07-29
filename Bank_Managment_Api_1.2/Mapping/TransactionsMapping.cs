using System;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;

namespace Bank_Managment_Api_1._2.Mapping;

public static class TransactionsMapping
{
    public static Transactions ToEntity(this CreateTransactionDto newTransaction, int BankId)
    {
        return new Transactions()
        {
            Timestamp = DateTime.Now.Date,
            StatusId = newTransaction.StatusId,
            BankAccountId = BankId,
            Beneficiary = newTransaction.Beneficiary,
            TransactionAmount = newTransaction.TransactionAmount,
            TransactionTypeId = newTransaction.TransactionTypeId,
        };    
    }
    public static TransactionDto ToTransactionDto(this Transactions transactions)
    {
        return new(
            transactions.Id,
            transactions.Timestamp,
            transactions.StatusId,
            transactions.BankAccountId,
            transactions.Beneficiary,
            transactions.TransactionAmount,
            transactions.TransactionTypeId
        );
    }
}
