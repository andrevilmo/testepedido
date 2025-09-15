using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace service;

public class Token
{
    public static string Create()
    {
        string tokenSecret = Environment.GetEnvironmentVariable("TOKEN_SECRET") ?? "";
        string cliente = Environment.GetEnvironmentVariable("BETHOUSE") ?? "";

        List<string> roles = new() { "ADMIN" };
        string rolesJson = JsonConvert.SerializeObject(roles, Formatting.Indented);

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            new Claim("roles", rolesJson, JsonClaimValueTypes.JsonArray),
            new Claim("type", "USER")
        };

        SymmetricSecurityKey chave = new(Encoding.UTF8.GetBytes(tokenSecret));
        SigningCredentials credenciais = new(chave, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken token = new(
            issuer: cliente.ToLower(),
            audience: "odd_post",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credenciais
        );

        string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenStr;
    }
}