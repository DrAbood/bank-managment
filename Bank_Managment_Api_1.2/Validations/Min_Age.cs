using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Managment_Api_1._2.validations;

public class MinAgeAttribute : ValidationAttribute
{
    private readonly int _minAge;

    public MinAgeAttribute(int minAge)
    {
        _minAge = minAge;
        ErrorMessage = $"Age must be at least {_minAge} years.";
    }

    public override bool IsValid(object? value)
    {
        if (value is DateTime dob)
        {
            var age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age)) age--; // Adjust if birthday not reached
            return age >= _minAge;
        }
        return false;
    }
}
