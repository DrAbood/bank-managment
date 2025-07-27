using System;
using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_Api_1._2.Helpfullclasses;

public static class HelpfulFunctions 
{
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

        return $"{todayPrefix}{nextSequence.ToString("D4")}";
    }
}
