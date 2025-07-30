using System;
using Bank_Managment_Api_1._2.Entities;

namespace Bank_Managment_Api_1._2.Mapping;

public static class TokenMapping
{
    public static TokenBlackList ToEntityFromString(string TokenId)
    {
        return new TokenBlackList()
        {
            Jiti = TokenId,
        };
    }
}
