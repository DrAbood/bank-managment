using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class AccountDetailsDto
(
    
    [StringLength(10)]string Numbers,
    [Required] [StringLength(35)] string HolderName,
    [Required] [StringLength(13)] string AssociatedPhoneNumber,
    decimal Balance,
    DateTime CreationDate,
    DateTime DateOfBirth,
    bool IsActive,
    int UserId,
    int CategoryId
);

