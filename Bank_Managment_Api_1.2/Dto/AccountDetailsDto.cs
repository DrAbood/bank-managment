using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_API.Dto;

public record class AccountDetailsDto
(
    
    [Required] [StringLength(10)]string Numbers,
    [Required] [StringLength(35)] string HolderName,
    [Required] [StringLength(13)] string AssociatedPhoneNumber,
    decimal Balance,
    DateTime CreationDate,
    DateTime DateOfBirth,
    bool IsActive = true

);

