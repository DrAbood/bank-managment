using System.ComponentModel.DataAnnotations;
using Bank_Managment_Api_1._2.validations;
namespace Bank_Managment_Api_1._2.Dto;

public record class CreateAccountDto
(
    [Required] [StringLength(35)] string HolderName,
    [Required] [StringLength(13)] string AssociatedPhoneNumber,
    decimal Balance,
    [MinAge(18)]
    DateTime DateOfBirth,
    bool IsActive = true
);