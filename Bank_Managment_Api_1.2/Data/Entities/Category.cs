using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Managment_Api_1._2.Entities;
[Table("category")]
public class Category
{
    [Key]
    public int Id { get; set; }
    public required string CategoryName { get; set; }
}
