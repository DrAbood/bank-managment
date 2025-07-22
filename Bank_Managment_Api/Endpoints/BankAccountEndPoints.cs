using System;
using Bank_Managment_API.Data;
using Bank_Managment_API.Dto;
using Bank_Managment_API.Entities;
using Bank_Managment_API.Mapping;
using Bank_Managment_API.miscoullenous;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bank_Managment_API.Endpoints;

public static class BankAccountEndpoints
{

    // private static readonly List<AccountDetailsDto> accounts = [
    //     new(
    //         "2507150000",
    //         "Abdulrahman",
    //         "50221482",
    //         150.4569m,
    //         new DateTime(2025,07,15),
    //         new DateTime(03,08,02),
    //         true
    //     )
    // ];

    // private static readonly List<DepositDto> depositLog=
    // [   new(
    //     "2507150000",
    //     50m
    //     )
    // ];

    // private static readonly List<WithdrawDto> WithdrawLog =
    // [
    //     new(
    //         "2507150000",
    //         50m
    //     )
    // ];
    public static RouteGroupBuilder MapBankAccountEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Account").WithParameterValidation();

        var GetAccountEndpointName = "GetAccount";

        //GET /Account/2507150000
        // to get a specific account from it's number
        group.MapGet("/{Number}", async (string Number,BankAccountContext dbContext) =>
        {
            BankAccount? account = await dbContext.bankaccount.FindAsync(Number);

            return account is null ?
            Results.NotFound() : Results.Ok(account.ToGameSummaryDto());
        }
        ).WithName(GetAccountEndpointName);

        //POST /Account
        //to add a new account
        group.MapPost("/",async (CreateAccountDto newAccount, BankAccountContext dbContext ) =>
        {
            // AccountDetailsDto account = new(
            //     DateTime.Now.ToString("yyMMdd") + accounts.Count.ToString("D4"),
            //     newAccount.HolderName,
            //     newAccount.AssociatedPhoneNumber,
            //     newAccount.Balance,
            //     DateTime.Now.Date,
            //     newAccount.DateOfBirth,
            //     newAccount.IsActive
            // );
            string number = await Helpfull_Functions.GenerateAccountNumber(dbContext);
            BankAccount account = newAccount.ToEntity(number);



            dbContext.bankaccount.Add(account);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetAccountEndpointName,
                 new { number = account.Number },
                  account.ToGameDetailsDto());
        }
        );
        //PUT /Account/2507150000
        //to update an account

        group.MapPut("/{Number}", async (string number, UpdateAccountDto updatedAccount,BankAccountContext dbContext) =>
        {
            var existingAcount = await dbContext.bankaccount.FindAsync(number);
            
            if (existingAcount is null)
            {
                return Results.NotFound();
            }

            // accounts[index] = new AccountDetailsDto(
            //     accounts[index].Numbers,
            //     updatedAccound.HolderName,
            //     updatedAccound.AssociatedPhoneNumber,
            //     accounts[index].Balance,
            //     accounts[index].CreationDate,
            //     accounts[index].DateOfBirth,
            //     accounts[index].IsActive
            // );

            dbContext.Entry(existingAcount)
                    .CurrentValues
                    .SetValues(updatedAccount.ToEntity(Number: number, balance: existingAcount.Balance, creationDate: existingAcount.CreationDate, DateOfBirth: existingAcount.DateOfBirth, IsActive: existingAcount.IsActive));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();

        }
        );
        // POST /Account/2507150000/deposit
        // to make a deposit as well as keep track of the depost being made as a log 

        group.MapPost("/{number}/Deposit", async(string number, Create_DepositDto NewDeposit, BankAccountContext dbContext) =>
         {
            var existingAcount = await dbContext.bankaccount.FindAsync(number);
            

            if (existingAcount is null)
             {
                 return Results.NotFound();
             }

             //commented not imporant code
             {// DepositDto DepositLog = new(
              //     number,
              //     NewDeposit.Balance
              // );

                 //     accounts[index] = new AccountDetailsDto(
                 //     accounts[index].Numbers,
                 //     accounts[index].HolderName,
                 //     accounts[index].AssociatedPhoneNumber,
                 //     accounts[index].Balance + NewDeposit.Balance,
                 //     accounts[index].CreationDate,
                 //     accounts[index].DateOfBirth,
                 //     accounts[index].IsActive
                 // );
             }

             Deposit deposit = NewDeposit.ToEntityFromDeposit(number: number);
                dbContext.deposits.Add(deposit);

                await dbContext.SaveChangesAsync();

                dbContext.Entry(existingAcount)
                    .CurrentValues
                    .SetValues(existingAcount.ToEntityFromDeposit_addDeposit(Number: number, Deposit: NewDeposit.Balance,balance:existingAcount.Balance, creationDate: existingAcount.CreationDate,DateOfBirth: existingAcount.DateOfBirth,IsActive:existingAcount.IsActive));

                await dbContext.SaveChangesAsync();
            


            return Results.NoContent();
         });

        group.MapPost("/{number}/Withdraw", async(string number, Create_WithdrawDto newWithdraw,BankAccountContext dbContext) =>
        {
             var existingAcount = dbContext.bankaccount.Find(number);
            

            if (existingAcount is null)
             {
                 return Results.NotFound();
             }
             //commented not imporant code
{
            //     DepositDto DepositLog = new(
            //         number,
            //         newWithdraw.Balance
            //     );

            //     accounts[index] = new AccountDetailsDto(
            //     accounts[index].Numbers,
            //     accounts[index].HolderName,
            //     accounts[index].AssociatedPhoneNumber,
            //     accounts[index].Balance - newWithdraw.Balance,
            //     accounts[index].CreationDate,
            //     accounts[index].DateOfBirth,
            //     accounts[index].IsActive
            // );
        }
                Withdraw withdraw = newWithdraw.ToEntityFromWithdraw(number: number);
                dbContext.withdraws.Add(withdraw);

                await dbContext.SaveChangesAsync();

                dbContext.Entry(existingAcount)
                    .CurrentValues
                    .SetValues(existingAcount.ToEntityFromWithdraw_addWithdraw(Number: number, Deposit: newWithdraw.Balance,balance:existingAcount.Balance, creationDate: existingAcount.CreationDate,DateOfBirth: existingAcount.DateOfBirth,IsActive:existingAcount.IsActive));

                await dbContext.SaveChangesAsync();
            
            return Results.NoContent();
        });


        return group;
    }
}
