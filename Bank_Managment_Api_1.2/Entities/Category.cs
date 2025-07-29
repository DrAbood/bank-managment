using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    public required string CategoryName { get; set; }
}
