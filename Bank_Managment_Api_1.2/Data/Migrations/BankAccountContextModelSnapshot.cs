﻿// <auto-generated />
using System;
using Bank_Managment_Api_1._2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Managment_Api_1._2.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    partial class BankAccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("Bank_Managment_Api_1._2.Entities.BankAccount", b =>
                {
                    b.Property<string>("BankNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssociatedPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("BankNumber");

                    b.ToTable("bankaccount");

                    b.HasData(
                        new
                        {
                            BankNumber = "2507220000",
                            AssociatedPhoneNumber = "50221482",
                            Balance = 150.4569m,
                            CreationDate = new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HolderName = "Abdulrahman",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Bank_Managment_Api_1._2.Entities.Deposit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("deposits");
                });

            modelBuilder.Entity("Bank_Managment_Api_1._2.Entities.Withdraw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("withdraws");
                });
#pragma warning restore 612, 618
        }
    }
}
