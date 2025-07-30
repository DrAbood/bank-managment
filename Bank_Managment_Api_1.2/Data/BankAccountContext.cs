using System;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Microsoft.EntityFrameworkCore;

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
        modelBuilder.Entity<Role>().HasData(
            new
            {
                Id = 1,
                RoleName = "customer"
            },
            new

            {
                Id = 2,
                RoleName = "teller"
            },
            new
            {
                Id = 3,
                RoleName = "admin"
            }
        );
        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                CategoryName = "vip"
            },
            new
            {
                Id = 2,
                CategoryName = "premium"
            },
            new
            {
                Id = 3,
                CategoryName = "regular"
            }
        );
        modelBuilder.Entity<TransactionType>().HasData(
            new
            {
                Id = 1,
                Type = "deposit"
            },
            new
            {
                Id = 2,
                Type = "withdraw"
            }
        );
        modelBuilder.Entity<TransactionStatus>().HasData(
            new
            {
                Id = 1,
                Status = "pending"
            },
            new
            {
                Id = 2,
                Status = "completed"
            },
            new
            {
                Id = 3,
                Status = "failed"
            },
            new
            {
                Id = 4,
                Status = "cancelled"
            },
            new
            {
                Id = 5,
                Status = "processing"
            }
        );
    }
}
