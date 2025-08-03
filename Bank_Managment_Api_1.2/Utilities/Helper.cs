using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bank_Managment_Api_1._2.Utilities;

public static class Helper
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

    // public static string GenerateJWTToken(string username)
    // {
    //     var claims = new[]
    //     {
    //         new Claim(JwtRegisteredClaimNames.Sub, username),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //     };
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some-key-that-will-change-eventually"));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //     var token = new JwtSecurityToken(
    //         issuer: "localHost",
    //         audience: "audience",
    //         claims: claims,
    //         expires: DateTime.Now.AddMinutes(30),
    //         signingCredentials: creds

    //     );
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}
