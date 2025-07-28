using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class UserDetailsDto
(
    [Required]int Id,
    [Required] string Name,
    string Email,
    DateTime CreationDate,
    DateTime DateOfBirth,
    string MobileNumber,
    string Role

);
