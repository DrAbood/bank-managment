// using System;

// namespace Bank_Managment_API.Endpoints;

// public class Deposit_WithdrawEndPoints
// {
//         public static RouteGroupBuilder MapBankAccountEndpoints(this WebApplication app)
//     {
//         var group = app.MapGroup("Account").WithParameterValidation();


//         group.MapPost("/{number}/Deposit", (string number, Create_DepositDto NewDeposit) =>
//          {
//             var index = accounts.FindIndex(account => account.Numbers == number);

//             if (index == -1 || accounts[index] is null)
//             {
//                 return Results.NotFound();
//             }

//             DepositDto DepositLog = new(
//                 number,
//                 NewDeposit.Balance
//             );

//                 accounts[index] = new AccountDetailsDto(
//                 accounts[index].Numbers,
//                 accounts[index].HolderName,
//                 accounts[index].AssociatedPhoneNumber,
//                 accounts[index].Balance + NewDeposit.Balance,
//                 accounts[index].CreationDate,
//                 accounts[index].DateOfBirth,
//                 accounts[index].IsActive
//             );
            


//             return Results.NoContent();
//          });

//         group.MapPost("/{number}/Withdraw", (string number, Create_WithdrawDto newWithdraw) =>
//         {
//             var index = accounts.FindIndex(account => account.Numbers == number);

//             if (index == -1 || accounts[index] is null)
//             {
//                 return Results.NotFound();
//             }

//             DepositDto DepositLog = new(
//                 number,
//                 newWithdraw.Balance
//             );

//             accounts[index] = new AccountDetailsDto(
//             accounts[index].Numbers,
//             accounts[index].HolderName,
//             accounts[index].AssociatedPhoneNumber,
//             accounts[index].Balance - newWithdraw.Balance,
//             accounts[index].CreationDate,
//             accounts[index].DateOfBirth,
//             accounts[index].IsActive
//         );
            
//             return Results.NoContent();
//         });


//         return group;
    
// }
