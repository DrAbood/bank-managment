using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_API.Dto;

public record class CreateAccountDto
(
    [StringLength(10)] string Number,
    [Required] [StringLength(35)] string HolderName,
    [Required] [StringLength(13)] string AssociatedPhoneNumber,
    decimal Balance,
    DateTime DateOfBirth,
    bool IsActive = true
);