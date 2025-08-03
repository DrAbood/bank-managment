using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bank_Managment_Api_1._2.Entities;

public class Deposit
{
    [Key]
    public int id { get; set; }

    [ForeignKey("BankAccount")]
    public required string Number { get; set; }
    public required decimal Balance { get; set; }
}
