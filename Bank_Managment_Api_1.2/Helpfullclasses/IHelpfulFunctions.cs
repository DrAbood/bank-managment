using System;
using Bank_Managment_Api_1._2.Data;

namespace Bank_Managment_Api_1._2.Helpfullclasses;

public interface IHelpfulFunctions
{
    Task<string> GenerateAccount(BankAccountContext db);
    Task<string> GenerateJWTToken(string UserName);
}
