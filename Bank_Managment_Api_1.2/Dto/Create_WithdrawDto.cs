using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class Create_WithdrawDto
(
    int id,
    string Number,
    [Range(5,20)] decimal Balance
);
