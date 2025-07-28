using System;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using BCrypt.Net;

namespace Bank_Managment_Api_1._2.Mapping;

public static class UserMapping
{
    public static User ToEntity(this CreateUserDto NewUser)
    {
        return new User()
        {
            // Id = NewUser.Id,
            Name = NewUser.Name,
            Email = NewUser.Email,
            CreationDate = DateTime.Now.Date,
            MobileNumber = NewUser.MobileNumber,
            DateOfBirth = NewUser.DateOfBirth,
            Role = NewUser.Role,
            HashedPassword = BCrypt.Net.BCrypt.HashPassword(NewUser.Password)
        };
    }

    public static UserDetailsDto ToUserDetailsDto(this User user)
    {
        return new(
            user.Id,
            user.Name,
            user.Email,
            user.CreationDate,
            user.DateOfBirth,
            user.MobileNumber,
            user.Role        
        );
    }
}
