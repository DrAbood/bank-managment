using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Bank_Managment_Api_1._2.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Email { get; set; }

    public required DateTime CreationDate { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? MobileNumber { get; set; }

    [ForeignKey("Role")]
    public required string Role { get; set; }
    
    public required string HashedPassword { get; set; }
 
}
