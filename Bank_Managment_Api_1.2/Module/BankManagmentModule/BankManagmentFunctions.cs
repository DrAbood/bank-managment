// using System;
// using Bank_Managment_Api_1._2.Data;
// using Bank_Managment_Api_1._2.Dto;
// using Bank_Managment_Api_1._2.Entities;
// using Bank_Managment_Api_1._2.Mapping;
// using Bank_Managment_Api_1._2.Module.BankManagmentModule;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// namespace Bank_Managment_Api_1._2.Module.BankManagmentModule;

// public class BankManagmentFunctions : IBankManagementFunctions
// {
//     private BankAccountContext _dbContext;

//     public BankManagmentFunctions(BankAccountContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//         public async Task<ActionResult<AccountSummaryDto>> GetAccount(string number)
//     {
//         BankAccount? account = await _dbContext.bankaccount.FindAsync(number);
//         if (account == null)
//         {
//             return NotFound();
//         }
//         return account.ToAccountSummaryDto();
//     }
 
// }
