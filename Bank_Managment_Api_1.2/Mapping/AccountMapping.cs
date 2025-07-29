using System;
using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_Api_1._2.Mapping;

public static class AccountMapping
{
    
    public static BankAccount ToEntity(this CreateAccountDto Account,string Number)
    {
        return new BankAccount()
        {
            // Number = Account.Number,
            BankNumber = Number,
            HolderName = Account.HolderName,
            AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
            Balance = Account.Balance,
            CreationDate = DateTime.Now.Date,
            DateOfBirth = Account.DateOfBirth,
            IsActive = Account.IsActive,
            UserID = Account.UserId,
            CategoryID = Account.CategoryId
        };
    }
    // public static BankAccount ToEntity(this UpdateAccountDto Account,
    // string Number,
    // decimal balance,
    // DateTime creationDate,
    // DateTime DateOfBirth,
    // bool IsActive
    // )
    // {
    //     return new BankAccount()
    //     {
    //         BankNumber = Number,
    //         // DateTime.Now.ToString("yyMMdd") + dbContext.bankaccount.Count.ToString("D4"),
    //         HolderName = Account.HolderName,
    //         AssociatedPhoneNumber = Account.AssociatedPhoneNumber,
    //         Balance = balance,
    //         CreationDate = creationDate,
    //         DateOfBirth = DateOfBirth,
    //         IsActive = IsActive
    //     };
    // }
    public static AccountDetailsDto ToAccountDetailsDto(this BankAccount Account)
    {
        return new(
            Account.BankNumber,
            Account.HolderName,
            Account.AssociatedPhoneNumber,
            Account.Balance,
            Account.CreationDate,
            Account.DateOfBirth,
            Account.IsActive,
            Account.UserID,
            Account.CategoryID
        );
    }

    public static AccountSummaryDto ToAccountSummaryDto(this BankAccount Account)
    {
        return new(
            Account.BankNumber,
            Account.HolderName,
            Account.AssociatedPhoneNumber,
            Account.Balance
        );
    }
    
}
