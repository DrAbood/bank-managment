using System;
using Bank_Managment_API.Data;
using Bank_Managment_API.Dto;
using Bank_Managment_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_API.Mapping;

public static class AccountMapping
{
    
    public static BankAccount ToEntity(this CreateAccountDto Account,string Number)
    {
        return new BankAccount()
        {
            // Number = Account.Number,
            Number = Number,
            HolderName = Account.HolderName,
            AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
            Balance = Account.Balance,
            CreationDate = DateTime.Now.Date,
            DateOfBirth = Account.DateOfBirth,
            IsActive = Account.IsActive
        };
    }
    public static BankAccount ToEntity(this UpdateAccountDto Account,
    string Number,
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
            Balance = balance,
            CreationDate = creationDate,
            DateOfBirth = DateOfBirth,
            IsActive = IsActive
        };
    }
    public static AccountDetailsDto ToGameDetailsDto(this BankAccount Account)
    {
        return new(
            Account.Number,
            Account.HolderName,
            Account.AssociatedPhoneNumber,
            Account.Balance,
            Account.CreationDate,
            Account.DateOfBirth,
            Account.IsActive
        );
    }

    public static AccountSummaryDto ToGameSummaryDto(this BankAccount Account)
    {
        return new(
            Account.Number,
            Account.HolderName,
            Account.AssociatedPhoneNumber,
            Account.Balance
        );
    }
    
}
