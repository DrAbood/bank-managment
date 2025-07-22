using System;
using System.Globalization;
using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Bank_Managment_Api_1._2.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_Api_1._2.Controller;

[Route("Account")]
[ApiController]

public class AccountController : ControllerBase
{
    private BankAccountContext _dbContext;

    public AccountController(BankAccountContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet("{number}")]
    public async Task<ActionResult<AccountSummaryDto>> GetAccount(string number)
    {
        BankAccount? account = await _dbContext.bankaccount.FindAsync(number);
        if (account == null)
        {
            return NotFound();
        }
        return account.ToAccountSummaryDto();
    }

    [HttpPost]
    public async Task<ActionResult<AccountDetailsDto>> PostAccount(CreateAccountDto newAccount)
    {
        string Generatednumber = await GenerateAccountNumber(_dbContext);
        // var account = new BankAccount
        // {
        //     // DateTime.Now.ToString("yyMMdd") + accounts.Count.ToString("D4"),
        //     BankNumber = Generatednumber,
        //     HolderName = newAccount.HolderName,
        //     AssociatedPhoneNumber = newAccount.AssociatedPhoneNumber,
        //     Balance = newAccount.Balance,
        //     CreationDate = DateTime.Now.Date,
        //     DateOfBirth = newAccount.DateOfBirth,
        //     IsActive = newAccount.IsActive
        // };
        BankAccount account = newAccount.ToEntity(Generatednumber);

        _dbContext.bankaccount.Add(account);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(
            nameof(GetAccount),
            new { number = account.BankNumber },
            account.ToAccountDetailsDto());
    }


    [HttpPatch("{number}")]
    public async Task<ActionResult> PatchAccount(string number, UpdateAccountDto updatedAccount)
    {
        var existingAcount = await _dbContext.bankaccount.FindAsync(number);
        if (existingAcount is null)
        {
            return NotFound();
        }
        if (updatedAccount.HolderName != null) existingAcount.HolderName = updatedAccount.HolderName;
        if (updatedAccount.AssociatedPhoneNumber != null) existingAcount.AssociatedPhoneNumber = updatedAccount.AssociatedPhoneNumber;
        await _dbContext.SaveChangesAsync();
        return NoContent();
        
    }



    public static async Task<string> GenerateAccountNumber(BankAccountContext db)
    {
        var todayPrefix = DateTime.Now.ToString("yyMMdd");

        var maxTodayNumber = await db.bankaccount
            .Where(a => a.BankNumber.StartsWith(todayPrefix))
            .OrderByDescending(a => a.BankNumber)
            .Select(a => a.BankNumber)
            .FirstOrDefaultAsync();

        int nextSequence = 1;

        if (!string.IsNullOrEmpty(maxTodayNumber))
        {
            var lastSeqStr = maxTodayNumber.Substring(6);
            nextSequence = int.Parse(lastSeqStr) + 1;
        }

        return $"{todayPrefix}{nextSequence.ToString("D5")}";
    }
}
