using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_API.Dto;

public record class DepositDto
(
    int id,
    [Required]string Number,
    [Required] [Range(5,20)]decimal Balance
);
