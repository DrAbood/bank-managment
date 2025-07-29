namespace Bank_Managment_Api_1._2.Dto;

public record class CreateTransactionDto
(
    int StatusId,
    string Beneficiary,
    decimal TransactionAmount,
    int TransactionTypeId
);
