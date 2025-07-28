using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public required string RoleName { get; set; }
}
