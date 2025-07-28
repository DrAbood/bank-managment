using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_API.Entities;

public class BankAccount
{
    // public int Id { get; set; }
    [Key]
    public required string Number { get; set; }

    public required string HolderName { get; set; }
    public required string AssociatedPhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime DateOfBirth { get; set; }    
}
