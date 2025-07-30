using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Managment_Api_1._2.Entities;

[Table("TransactionsType")]
public class TransactionType
{
    [Key]
    public int Id { get; set; }

    public required string Type { get; set; }
}
