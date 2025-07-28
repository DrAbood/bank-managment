using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class CreateUser
(
    [Required] int id,
    [Required] string name,
    string email,
    string MobileNumber,
    DateTime DateOfBirth,
    [Required] [Range(8,20)] string Password

);
