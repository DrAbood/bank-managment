namespace Bank_Managment_Api_1._2.Dto;

public record class TransactionDto
(
    Guid Id,
    DateTime TimeStamp,
    int StatusId,
    int BankAccoutnId,
    string Beneficiary,
    decimal TransactionAmount,
    int TransactionTypeId
);
