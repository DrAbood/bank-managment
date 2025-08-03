using System.ComponentModel.DataAnnotations;
using Bank_Managment_Api_1._2.validations;
using Bank_Managment_Api_1._2.Validations;

namespace Bank_Managment_Api_1._2.Dto;

public record class CreateUserDto
(
    [Required] string Name,
    string Email,
    [StringLength(13)]string MobileNumber,
    [MinAge(18)]DateTime DateOfBirth,
    [Required] [ValidRole] string Role,
    [StringLength(maximumLength: 20, MinimumLength = 8)] string Password
);
