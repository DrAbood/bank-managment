using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bank_Managment_Api_1._2.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Email { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? MobileNumber { get; set; }
    
    public required string HashedPassword { get; set; }
 
}
