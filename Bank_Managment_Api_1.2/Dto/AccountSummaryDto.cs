using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.Dto;

public record class AccountSummaryDto
(

    [Required][StringLength(10)] string Numbers,
    [Required][StringLength(35)] string HolderName,
    [Required][StringLength(13)] string AssociatedPhoneNumber,
    decimal Balance

);

