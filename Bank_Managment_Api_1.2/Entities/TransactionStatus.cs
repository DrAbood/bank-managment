using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Entities;

public class TransactionStatus
{
    [Key]
    public int Id { get; set; }

    public required string Status { get; set; }
}
