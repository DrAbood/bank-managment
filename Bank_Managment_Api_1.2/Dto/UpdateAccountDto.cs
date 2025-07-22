using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class UpdateAccountDto(
    [Required] [StringLength(35)] string HolderName,
    [Required] [StringLength(13)] string AssociatedPhoneNumber
);
