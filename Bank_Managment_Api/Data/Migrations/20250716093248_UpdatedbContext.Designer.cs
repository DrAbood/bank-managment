﻿// <auto-generated />
using System;
using Bank_Managment_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Managment_API.Data.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    [Migration("20250716093248_UpdatedbContext")]
    partial class UpdatedbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("Bank_Managment_API.Entities.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

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

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("bankaccount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssociatedPhoneNumber = "50221482",
                            Balance = 150.4569m,
                            CreationDate = new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HolderName = "Abdulrahman",
                            IsActive = true,
                            Number = "2507150000"
                        });
                });

            modelBuilder.Entity("Bank_Managment_API.Entities.Deposit", b =>
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

            modelBuilder.Entity("Bank_Managment_API.Entities.Withdraw", b =>
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
