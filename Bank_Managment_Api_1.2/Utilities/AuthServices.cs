using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Bank_Managment_Api_1._2.Utilities;

public class AuthServices
{
    public static string GenerateJWTToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some-key-that-will-change-eventually"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "localHost",
            audience: "audience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds

        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
