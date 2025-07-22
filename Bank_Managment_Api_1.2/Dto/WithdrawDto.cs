using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class WithdrawDto
(
    int id,
    [Required] [StringLength(10)]string Number,
    [Required] [Range(5,100)]decimal Balance
);