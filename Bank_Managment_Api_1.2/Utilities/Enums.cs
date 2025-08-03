using System;

namespace Bank_Managment_Api_1._2.Utilities;

public static class Enums
{
    public enum UserRole
    {
        customer,
        teller,
        admin
    }

    public enum Categorys
    {
        vip,

        premium,

        regular
    }

    public enum TransactionTypes
    {
        deposit,

        withdraw
    }

    public enum TransactionStatuses
    {
        pending,

        completed,

        failed,

        cancelled,

        processing
    }
}
