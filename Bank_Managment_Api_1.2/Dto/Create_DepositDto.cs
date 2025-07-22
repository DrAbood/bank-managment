using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class Create_DepositDto
(
    int id,
    string Number,
    [Range(5,100)] decimal Balance
);
