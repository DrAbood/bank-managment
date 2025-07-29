using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bank_Managment_Api_1._2.Entities;

[Table("bankaccount")]
public class BankAccount
{
    [Key]
    public int Id { get; set; }

    public required string BankNumber { get; set; }

    public required string HolderName { get; set; }
    public required string AssociatedPhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime DateOfBirth { get; set; }

    public required int CategoryID { get; set; }

    [ForeignKey("CategoryID")]
    public Category? category { get; set; }
    public required int UserID { get; set; }

    [ForeignKey("UserID")]
    public User? user { get; set; }
}
