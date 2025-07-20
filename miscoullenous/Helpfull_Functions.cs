using System;
using Bank_Managment_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_API.miscoullenous
{
    public static class Helpfull_Functions
    {
        public static async Task<string> GenerateAccountNumber(BankAccountContext db)
        {
            var todayPrefix = DateTime.Now.ToString("yyMMdd");

            var maxTodayNumber = await db.bankaccount
                .Where(a => a.Number.StartsWith(todayPrefix))
                .OrderByDescending(a => a.Number)
                .Select(a => a.Number)
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
}
