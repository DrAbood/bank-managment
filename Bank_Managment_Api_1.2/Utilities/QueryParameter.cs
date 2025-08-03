using System;
using Bank_Managment_Api_1._2.Entities;

namespace Bank_Managment_Api_1._2.Utilities;

public class QueryParameter
{
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public string? TransactionType { get; set; } = null;
}
