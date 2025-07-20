using System;
using Bank_Managment_API.Dto;
using Bank_Managment_API.Entities;

namespace Bank_Managment_API.Mapping;

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
            Number = Number,
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
            Number = Number,
            HolderName = Account.HolderName,
            AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
            Balance = balance - Deposit,
            CreationDate = creationDate,
            DateOfBirth = DateOfBirth,
            IsActive = IsActive
        }; 
    }
    
}
