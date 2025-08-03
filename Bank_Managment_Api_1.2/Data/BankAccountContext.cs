using System;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using static Bank_Managment_Api_1._2.Utilities.Enums;

namespace Bank_Managment_Api_1._2.Data;

public class BankAccountContext(DbContextOptions<BankAccountContext> options) : DbContext(options)
{
    public DbSet<BankAccount> bankaccount => Set<BankAccount>();

    public DbSet<Deposit> deposits => Set<Deposit>();
    
    public DbSet<Withdraw> withdraws => Set<Withdraw>();

    public DbSet<User> users => Set<User>();

    public DbSet<Role> roles => Set<Role>();

    public DbSet<Category> categories => Set<Category>();

    public DbSet<Transactions> transactions=> Set<Transactions>();

    public DbSet<TransactionStatus> transactionsstatus => Set<TransactionStatus>();

    public DbSet<TransactionType> transactiontypes => Set<TransactionType>();

    public DbSet<TokenBlackList> tokenblacklist => Set<TokenBlackList>();

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<BankAccount>().HasData(
    //         new
    //         {
    //             // Id = 1,
    //             BankNumber = "2507220000",
    //             HolderName = "Abdulrahman",
    //             AssociatedPhoneNumber = "50221482",
    //             Balance = 150.4569m,
    //             CreationDate = new DateTime(2025, 07, 15),
    //             DateOfBirth = new DateTime(03, 08, 02),
    //             IsActive = true
    //         }
    //     );
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
                        .Property(u => u.RoleName)
                        .HasConversion<string>();  
                          
        modelBuilder.Entity<Category>()
                        .Property(u => u.CategoryName)
                        .HasConversion<string>();
        modelBuilder.Entity<Role>().HasData(
            new
            {
                Id = 1,
                RoleName = UserRole.customer.ToString()
            },
            new

            {
                Id = 2,
                RoleName = UserRole.teller.ToString()
            },
            new
            {
                Id = 3,
                RoleName = UserRole.admin.ToString()
            }
        );


        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                CategoryName = Categorys.vip.ToString()
            },
            new
            {
                Id = 2,
                CategoryName = Categorys.premium.ToString()
            },
            new
            {
                Id = 3,
                CategoryName = Categorys.regular.ToString()
            }
        );

        modelBuilder.Entity<TransactionType>()
                .Property(u => u.Type)
                .HasConversion<string>();

        modelBuilder.Entity<TransactionType>().HasData(
            new
            {
                Id = 1,
                Type = TransactionTypes.deposit.ToString()
            },
            new
            {
                Id = 2,
                Type = TransactionTypes.withdraw.ToString()
            }
        );
        modelBuilder.Entity<TransactionStatus>()
                .Property(u => u.Status)
                .HasConversion<string>();

        modelBuilder.Entity<TransactionStatus>().HasData(
            new
            {
                Id = 1,
                Status = TransactionStatuses.pending.ToString()
            },
            new
            {
                Id = 2,
                Status = TransactionStatuses.completed.ToString()
            },
            new
            {
                Id = 3,
                Status = TransactionStatuses.failed.ToString()
            },
            new
            {
                Id = 4,
                Status = TransactionStatuses.cancelled.ToString()
            },
            new
            {
                Id = 5,
                Status = TransactionStatuses.processing.ToString()
            }
        );
    }
}
