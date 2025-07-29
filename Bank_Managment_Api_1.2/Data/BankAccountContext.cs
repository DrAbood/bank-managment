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
                RoleName = "Customer"
            },
            new

            {
                Id = 2,
                RoleName = "Teller"
            },
            new
            {
                Id = 3,
                RoleName = "Admin"
            }
        );
        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                CategoryName = "VIP"
            },
            new
            {
                Id = 2,
                CategoryName = "Premium"
            },
            new
            {
                Id = 3,
                CategoryName = "Regular"
            }
        );
    }
}
