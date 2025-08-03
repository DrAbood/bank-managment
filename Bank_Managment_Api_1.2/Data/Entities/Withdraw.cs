using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Managment_Api_1._2.Entities;

public class Withdraw
{   
    [Key]
    public int Id { get; set; }
    [ForeignKey("BankAccount")]
    public required string Number { get; set; }
    public required decimal Balance { get; set; }
}
