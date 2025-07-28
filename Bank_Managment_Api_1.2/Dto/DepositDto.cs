using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class DepositDto
(
    int id,
    [Required]string Number,
    [Required] [Range(5,20)]decimal Balance
);
