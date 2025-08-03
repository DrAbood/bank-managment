using System;
using System.ComponentModel.DataAnnotations;
using static Bank_Managment_Api_1._2.Utilities.Enums;

namespace Bank_Managment_Api_1._2.Validations;

public class ValidRole : ValidationAttribute
{
    // private readonly string _Role;

    // public ValidRole(string Role)
    // {
    //     _Role = Role;
    //     ErrorMessage = "invalid Role";
    // }

    public override bool IsValid(object? value)
    {
        if (value is not string input)
        {
            return false;
        }
        if (value != null)
        {
            return Enum.IsDefined(typeof(UserRole), value);
        }
        return false;
    }

}
