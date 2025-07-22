using System;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;

namespace Bank_Managment_Api_1._2.Mapping;

public static class Deposit_WithdrawMapping
{
    public static Deposit ToEntityFromDeposit(this Create_DepositDto deposit, string number)
    {
        return new Deposit()
        {
            Number = number,
            Balance = deposit.Balance
        };
    }
    public static Withdraw ToEntityFromWithdraw(this Create_WithdrawDto deposit, string number)
    {
        return new Withdraw()
        {
            Number = number,
            Balance = deposit.Balance
        };
    }
    public static BankAccount ToEntityFromDeposit_addDeposit(this BankAccount Account,
    string Number,
    decimal Deposit,
    decimal balance,
    DateTime creationDate,
    DateTime DateOfBirth,
    bool IsActive
    )
    {
        return new BankAccount()
        {
            BankNumber = Number,
            // DateTime.Now.ToString("yyMMdd") + dbContext.bankaccount.Count.ToString("D4"),
            HolderName = Account.HolderName,
            AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
            Balance = balance + Deposit,
            CreationDate = creationDate,
            DateOfBirth = DateOfBirth,
            IsActive = IsActive
        };
    }
        public static BankAccount ToEntityFromWithdraw_addWithdraw(this BankAccount Account,
        string Number,
        decimal Deposit,
        decimal balance,
        DateTime creationDate,
        DateTime DateOfBirth,
        bool IsActive
        )
    {
        return new BankAccount()
        {
            BankNumber = Number,
            HolderName = Account.HolderName,
            AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
            Balance = balance - Deposit,
            CreationDate = creationDate,
            DateOfBirth = DateOfBirth,
            IsActive = IsActive
        }; 
    }
    
}
